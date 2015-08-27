--ALTER USER system IDENTIFIED BY default;
--connect system/default
create user money identified by exchanger;
commit;
--connect system/default GRANT UNLIMITED TABLESPACE TO money;
--GRANT CREATE SESSION, CREATE USER, CREATE TABLE TO money; 
--GRANT EXECUTE ANY PROCEDURE TO money WITH ADMIN OPTION;
select * from cat;
--drop table currency;
--purge recyclebin;

purge recyclebin;

commit;


------ Creation of DB----------

--  --
-- eof  --


-- Users --
create table users(
u_username varchar2(20),
u_password varchar2(20) not null,
constraint users_pk primary key (u_username)
);
insert into users(u_username,u_password) values ('admin','admin');
insert into users(u_username,u_password) values ('ali','ali');
update users set u_password='ali' where u_username='ali' and u_password='ali2';
select * from users;
commit;
select u_username from users where u_username='admin' and u_password='admin';
select u_username from users where u_username='ali' and u_password='ali';
-- eof Users --

-- currency --
create table currency(
currency_id varchar2(5),
currency_name varchar2(50) not null,
currency_amount number(20) not null,
constraint currecy_pk primary key (currency_id)
);
select * from cat;
select * from currency;
select * from currency where currency_amount!=0;
--drop table currency;
--insert into currency(currency_id,currency_name,currency_amount) values ('','',);
-- eof Users --

-- Customers --
create table customers(
customers_id number(6),
customers_name varchar2(20) not null,
customers_cnic varchar2(13),
customers_cell varchar2(20),
constraint customers_pk primary key (customers_id)
);
select * from customers;
drop table customers;
purge recyclebin;
insert into customers(customers_id,customers_name,customers_cnic,customers_cell) values (,'','','');
insert into customers(customers_id,customers_name,customers_cnic,customers_cell) values (1,'Hasaan','3710506784325','00923001234567');
select * from customers where customers_cnic='3710506784325';
select customers_id from customers where customers_cnic='3710506784325';
select customers_id from customers order by customers_id desc;

commit;
-- eof Customers --



-- Collection --
CREATE TABLE collections (
collect_id number(5),
collect_time date not null,
CONSTRAINT collect_pk PRIMARY KEY (collect_id) );
SELECT * FROM tab;
SELECT * FROM collections;
drop table collections;
purge recyclebin;
commit;
insert into collections(collect_id,collect_time) values ( 1, to_date('07/12/2014 12:31:20', 'dd/mm/yyyy hh24:mi:ss') );
-- eof Collection --


-- Rates --

CREATE TABLE rates(
rates_id number(10),
rates_from varchar2(5),
rates_to varchar2(5),  
collect_id number(5),
rate number(10,6) not null, 
CONSTRAINT rates_pk PRIMARY KEY (rates_id),
CONSTRAINT rates_from_fk FOREIGN KEY (rates_from) REFERENCES currency(currency_id),
CONSTRAINT rates_to_fk FOREIGN KEY (rates_to) REFERENCES currency(currency_id),
CONSTRAINT collect_id_fk FOREIGN KEY (collect_id) REFERENCES collections(collect_id)          );
drop table rates;
purge recyclebin;
select * from cat;
select * from rates;
select * from rates order by rates_id desc;
select * from currency where currency_amount!=0;

select * from rates where rates_from='PKR' or rates_to='PKR' order by rates_id;
select rates_id, rates_from, rates_to , rate from rates order by rates_id desc;
select rates_id,rates_from,rates_to , rate from (select rates_id, rates_from, rates_to , rate from rates order by rates_id desc)order  by rates_id desc;
select rates_id from rates order by rates_id desc;
insert into rates(rates_id,rates_from ,rates_to ,collect_id,rate) values (2,'PKR','AED', 1 , 0.0363);
insert into rates(rates_id,rates_from ,rates_to ,collect_id,rate) values (2,'PKR','AED', to_date('07/12/2014 12:31:20', 'dd/mm/yyyy hh24:mi:ss') , 0.0363);
commit;
-- Updation
select * from rates where rates_to!='PKR';
update rates set rate=round(((1/rate)*1.01),2) where rates_from='PKR';
--- eof Updation
-- bysell query
select * from rates;
select rates_id from rates where rate=100.625  and rates_from='USD' and rates_to='PKR' order by rates_id desc; -- by
select rates_id from rates where rate=102.0202  and rates_from='PKR' and rates_to='USD' order by rates_id desc; -- by

-- eof bysell query



select cr.currency_name as Curency ,  r1.rates_from as Symbol , 
round(r1.rate,2) as Buy , round(((1/r2.rate)*1.01),2) as Sell 
from 
rates r1, rates r2 , currency cr
where 
r1.rates_from=r2.rates_to and
r1.rates_to=r2.rates_from and
r1.rates_from=cr.currency_id and
r1.rates_from!='PKR' and
r1.collect_id=3 and
r2.collect_id=3 
order by cr.currency_name;
-- Check
select cr.currency_name as Curency ,  r1.rates_from as Symbol , 
r1.rate as Buy , r2.rate as Sell 
from 
rates r1, rates r2 , currency cr
where 
r1.rates_from=r2.rates_to and
r1.rates_to=r2.rates_from and
r1.rates_from=cr.currency_id and
r1.rates_from!='PKR' and
r1.collect_id=5 and
r2.collect_id=5 
--and r1.rate>r2.rate
order by cr.currency_name ;

delete from rates where collect_id=4;
delete from collections where collect_id=4;
commit;
select cr.currency_name as Currency, r1.rates_from as Curency , r1.rate as Buy , r2.rate as Sell
from rates r1, rates r2, currency cr
where r1.rates_from=r2.rates_to and
r1.rates_to=r2.rates_from and 
r1.rates_from=cr.currency_id and
r1.rates_from!='PAK' and r1.collect_id=1 and r2.collect_id=1;
-------



select r1.rates_from as "Curency" , r1.rates_from||'-'||r1.rates_to as "Buy",r1.rate as "Buy" , r2.rates_from||'-'||r2.rates_to as "Sell"
, r2.rate as "Sell" from rates r1, rates r2 
where 
r1.rates_from=r2.rates_to and
r1.rates_to=r2.rates_from and
r1.rates_from!='PKR' and
r1.collect_id=1 and
r2.collect_id=1;


-- eof Rates --


-- Exchange --

CREATE TABLE exchanges(
exchanges_id number(10),
customer_fk number(6),
rates_fk number(10),
users_fk varchar2(20),
exchanges_amount number(20,10) not null,
exchanges_time date not null,
CONSTRAINT exchanges_pk PRIMARY KEY (exchanges_id),
CONSTRAINT rates_id_fk FOREIGN KEY (rates_fk) REFERENCES rates(rates_id),  
CONSTRAINT customers_id_fk FOREIGN KEY (customer_fk) REFERENCES customers(customers_id),
CONSTRAINT users_id_fk FOREIGN KEY (users_fk) REFERENCES users(u_username)
); 
drop table exchanges;
purge recyclebin;
commit;
select * from cat;
select * from exchanges;
select * from rates;
select exchanges_id from exchanges order by exchanges_id desc;

insert into exchanges(exchanges_id, customer_fk, rates_fk , exchanges_amount , exchanges_time ) 
values ( , , , , to_date('04/11/2014 20:03:44', 'dd/mm/yyyy hh24:mi:ss'));

select * from rates where rates_from='AED' order by rates_id desc;

insert into exchanges(exchanges_id, customer_fk, rates_fk ,users_fk, exchanges_amount , exchanges_time ) 
values ( 1, 1,353 ,'ali', 1000, to_date('12/12/2014 23:57:44', 'dd/mm/yyyy hh24:mi:ss'));

-- GetCurrSaleReports (string name, DateTime fm, DateTime to)
select * from exchanges;
select * from rates;
select   exchanges_time, sum(exchanges_amount) from exchanges group by (exchanges_time);
select  exchanges_amount , trunc(exchanges_time) from exchanges;

-- correct
select   times, sum(exchanges_amount) from ( select  exchanges_amount , trunc(exchanges_time) as times from exchanges) group by times;

select substr(to_date(timefm),1,10) , sum(exchanges_amount) from
(select trunc(exchanges_time) as timefm ,  exchanges_amount from exchanges ) 
group by timefm ;

-- Correct 2 subqueries
select to_date(timefm) times_fm, sum(amountfm) from
(select trunc(ex.exchanges_time) as timefm , ex.exchanges_amount as amountfm from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='USD'  and rt.rates_to='PKR' 
and 
( trunc(ex.exchanges_time) between to_date('2014/12/20 00:00:00', 'yyyy/mm/dd hh24:mi:ss')  and to_date('2014/12/21 00:00:00', 'yyyy/mm/dd hh24:mi:ss') )
) 
group by timefm ;

select to_date(timeto) , sum(amountto) from
(
select trunc(ex.exchanges_time) as timeto , ex.exchanges_amount as amountto from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='PKR'  and rt.rates_to='USD'
) 
group by timeto ;



--// main query
select NVL(substr(to_date(time_to),1,10),substr(to_date(time_fm),1,10))  as "Date" , NVL(amount_fm,0) Buy , NVL(amount_to,0) Sell from
(
select to_date(timefm) time_fm, sum(amountfm) as amount_fm from
(select trunc(ex.exchanges_time) as timefm , ex.exchanges_amount as amountfm from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='USD'  and rt.rates_to='PKR'  
and 
( trunc(ex.exchanges_time) between to_date('2014/12/20 00:00:00', 'yyyy/mm/dd hh24:mi:ss')  and to_date('2014/12/22 23:59:59', 'yyyy/mm/dd hh24:mi:ss') )
) 
group by timefm
) FULL OUTER JOIN
(
select to_date(timeto) time_to, sum(amountto) as amount_to from
(select trunc(ex.exchanges_time) as timeto , ex.exchanges_amount as amountto from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='PKR'  and rt.rates_to='USD' 
and 
( trunc(ex.exchanges_time) between to_date('2014/12/20 00:00:00', 'yyyy/mm/dd hh24:mi:ss')  and to_date('2014/12/22 23:59:59', 'yyyy/mm/dd hh24:mi:ss') )
) 
group by timeto 
)
on 
time_fm=time_to order by "Date";
--


-- eof Correct 2 subqueries

select   TO_DATE((timesfm), 'yyyy/mm/dd hh24:mi:ss') as datee, sum(amountfm) from 
( select trunc(ex.exchanges_time) as timesfm , ex.exchanges_amount as amountfm from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='USD'  and rt.rates_to='PKR') 
group by datee;

select   timesto, sum(amountto) from 
(select trunc(ex.exchanges_time) as timesto , ex.exchanges_amount as amountto from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='PKR'  and rt.rates_to='USD' )
group by timesto;





select trunc(ex.exchanges_time) as timesfm , ex.exchanges_amount as amountfm from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='USD'  and rt.rates_to='PKR'  ;

select trunc(ex.exchanges_time) as timesto , ex.exchanges_amount as amountto from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and rt.rates_from='PKR'  and rt.rates_to='USD'  ;

select ex.exchanges_id, ex.exchanges_amount, ex.rates_fk, ex.customer_fk, ex.exchanges_time from exchanges ex, rates rt 
where ex.rates_fk=rt.rates_id and (rt.rates_from='USD' or rt.rates_to='USD');
-- Date / Buy / Sell
select ex.exchanges_id, ex.exchanges_amount, ex.rates_fk, ex.customer_fk, to_date(ex.exchanges_time) from exchanges ex;
select ex.exchanges_id, ex.exchanges_amount, ex.rates_fk, ex.customer_fk, TO_CHAR(ex.exchanges_time) from exchanges ex;


select ex.exchanges_id, ex.exchanges_amount, ex.rates_fk, ex.customer_fk, TO_DATE(TO_CHAR(ex.exchanges_time), 'dd/mm/yyyy') from exchanges ex;

select trunc(sysdate) from dual;

-- eof Exchange --
create table num_test(
num number(6,4)
);
insert into num_test values(34.4567);
insert into num_test values(0.4567);
insert into num_test values(232);
select * from num_test;
drop table num_test;
purge recyclebin;
commit;





create table date_test(
my_date date
);
alter session set nls_date_format = 'dd/MON/yyyy hh24:mi:ss'; -- to show time with date
alter session set nls_date_format = 'dd/mm/yyyy hh24:mi:ss'; -- to show time with date

select * from date_test order by my_date desc;

insert into date_test (my_date) values (to_date('2003/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'));
insert into date_test (my_date) values (to_date('04/11/2014 20:03:44', 'dd/mm/yyyy hh24:mi:ss'));   -- 04/NOV/2014 20:03:44

drop table date_test;
purge recyclebin;
commit;


