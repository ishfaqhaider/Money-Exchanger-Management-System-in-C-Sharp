using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money_Exchanger_Server_Side
{
    public class CurrencyList
    {
        public List<Currency> Cur_List=new List<Currency>();
        public CurrencyList() {
			Cur_List.Add(new Currency("AED","United Arab Emirates Dirham (AED)"));
			Cur_List.Add(new Currency("AFN","Afghan Afghani (AFN)"));
			Cur_List.Add(new Currency("AUD","Australian Dollar (A$)"));
			Cur_List.Add(new Currency("BDT","Bangladeshi Taka (BDT)"));
			Cur_List.Add(new Currency("CAD","Canadian Dollar (CA$)"));
			Cur_List.Add(new Currency("CHF","Swiss Franc (CHF)"));
			Cur_List.Add(new Currency("CNY","Chinese Yuan (CN¥)"));
			Cur_List.Add(new Currency("EGP","Egyptian Pound (EGP)"));
			Cur_List.Add(new Currency("EUR","Euro (€)"));
			Cur_List.Add(new Currency("GBP","British Pound Sterling (£)"));
			Cur_List.Add(new Currency("HKD","Hong Kong Dollar (HK$)"));
			Cur_List.Add(new Currency("IDR","Indonesian Rupiah (IDR)"));
			Cur_List.Add(new Currency("IEP","Irish Pound (IEP)"));
			Cur_List.Add(new Currency("ILS","Israeli New Sheqel"));
			Cur_List.Add(new Currency("INR","Indian Rupee (Rs.)"));
			Cur_List.Add(new Currency("IQD","Iraqi Dinar (IQD)"));
			Cur_List.Add(new Currency("IRR","Iranian Rial (IRR)"));
			Cur_List.Add(new Currency("ITL","Italian Lira (ITL)"));
			Cur_List.Add(new Currency("JPY","Japanese Yen (¥)"));
			Cur_List.Add(new Currency("KES","Kenyan Shilling (KES)"));
			Cur_List.Add(new Currency("KPW","North Korean Won (KPW)"));
            Cur_List.Add(new Currency("KRW", "South Korean Won")); 
			Cur_List.Add(new Currency("KWD","Kuwaiti Dinar (KWD)"));
			Cur_List.Add(new Currency("LKR","Sri Lankan Rupee (LKR)"));
			Cur_List.Add(new Currency("LRD","Liberian Dollar (LRD)"));
			Cur_List.Add(new Currency("LYD","Libyan Dinar (LYD)"));
			Cur_List.Add(new Currency("MAD","Moroccan Dirham (MAD)"));
			Cur_List.Add(new Currency("MYR","Malaysian Ringgit (MYR)"));
			Cur_List.Add(new Currency("NGN","Nigerian Naira (NGN)"));
			Cur_List.Add(new Currency("NOK","Norwegian Krone (NOK)"));
			Cur_List.Add(new Currency("NPR","Nepalese Rupee (NPR)"));
			Cur_List.Add(new Currency("NZD","New Zealand Dollar (NZ$)"));
			Cur_List.Add(new Currency("OMR","Omani Rial (OMR)"));
			Cur_List.Add(new Currency("PHP","Philippine Peso (Php)"));
			Cur_List.Add(new Currency("QAR","Qatari Rial (QAR)"));
			Cur_List.Add(new Currency("RUB","Russian Ruble (RUB)"));
			Cur_List.Add(new Currency("SAR","Saudi Riyal (SAR)"));
			Cur_List.Add(new Currency("SDG","Sudanese Pound (SDG)"));
			Cur_List.Add(new Currency("SEK","Swedish Krona (SEK)"));
			Cur_List.Add(new Currency("SGD","Singapore Dollar (SGD)"));
			Cur_List.Add(new Currency("TRY","Turkish Lira (TRY)"));
			Cur_List.Add(new Currency("UAH","Ukrainian Hryvnia (UAH)"));
			Cur_List.Add(new Currency("USD","US Dollar ($)"));
			Cur_List.Add(new Currency("YER","Yemeni Rial (YER)"));
			Cur_List.Add(new Currency("ZAR","South African Rand (ZAR)"));
			Cur_List.Add(new Currency("ZWL","Zimbabwean Dollar (2009) (ZWL)"));
            } // CurrencyList()

    }
     public class Currency {
        String currency_id;
        String currency_name;
        public Currency(String id, String nm) { 
        currency_id = id;
        currency_name = nm;
        }
        public String Get_ID()
        {
            return currency_id;
        }
        public String Get_Name()
        {
            return currency_name;
        }
    }
}
