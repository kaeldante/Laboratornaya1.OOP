using System;
using System.Collections.Generic;
using System.Linq;
class Program {
  public class Buyer
    {
        private double[] _paymentHistory;
        private double _discountProvided;
 
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public long CrediCardNumber { get; set; }
        public double DiscountProvided
        {
            get { return _discountProvided; }
            set { _discountProvided = value >= 100 ? 100 : value; }
        }
        public double[] PaymentHistory
        {
            get { return _paymentHistory; }
            set
            {
                _paymentHistory = new double[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    _paymentHistory[i] = DiscountProvided == 0 ? value[i] : value[i] * ((100 - DiscountProvided) * 0.01);
                }
            }
        }
 
 
        public override string ToString()
        {
            return $"{Name};{SurName};{Patronymic};{Address};{CrediCardNumber};{DiscountProvided}%";
        }
 
 
    }
  public static void Main (string[] args) {
    Console.WriteLine("============================");
    Console.WriteLine("Cписок покупателей от наибольшей к наименьшей скидке:");

    var buyers = new List<Buyer>()
            {
                new Buyer(){Name="Иванов",SurName="Иван",Patronymic="Иванович",Address="Омск",CrediCardNumber=892133,DiscountProvided=25,PaymentHistory=new double[]{100,200,300,400,500} },
                new Buyer(){Name="Петров",SurName="Петр",Patronymic="Петрович",Address="Новосибирск",CrediCardNumber=881912,DiscountProvided=30,PaymentHistory=new double[]{100.50,500} },
                new Buyer(){Name="Сергеев",SurName="Сергей",Patronymic="Сергеевич",Address="Омск",CrediCardNumber=988377,DiscountProvided=45,PaymentHistory=new double[]{10000.7,500.67,97.69} },
             }.OrderByDescending(i => i.DiscountProvided);
 
            foreach (var buyer in buyers)
            {
              
                Console.WriteLine(buyer.ToString());
            }
 
            var bestBuyer = buyers.FirstOrDefault(i => i.PaymentHistory.Sum() == buyers.Max(i => i.PaymentHistory.Sum()));
 
            Console.WriteLine("============================");
            Console.WriteLine($"Лучший покупатель: {bestBuyer.ToString()}");
 Console.WriteLine("============================");
 Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
  }
  
}
