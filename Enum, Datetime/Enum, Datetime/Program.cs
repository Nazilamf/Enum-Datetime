using System;
using System.Security.Cryptography;

namespace Enum__Datetime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            Group[] groups = new Group[0];


            string opt;
            do
            {
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Qruplara bax");
                Console.WriteLine("3. Type deyerine gore qruplara bax");
                Console.WriteLine("4. Bugunedek baslamıs qruplara bax");
                Console.WriteLine("5. Son 2 ayda baslamıs qruplara bax");
                Console.WriteLine("6. Bu ayın sonunadek yeni baslayacaq olan qruplara bax");
                Console.WriteLine("7. Verilmis 2 tarix aralıgnda baslamıs olan qruplara bax");
                Console.WriteLine("0. Cixis");

                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no = Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");


                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);

                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;


                        Console.WriteLine("StartDate:");
                        string startDatestr = Console.ReadLine();
                        DateTime startDate = Convert.ToDateTime(startDatestr);

                        Group group = new Group
                        {
                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;

                        break;
                    case "2":
                        foreach (var gr in groups)
                        {
                            Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;
                    case "3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                        Console.WriteLine("Type:");
                        typeStr = Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;

                        foreach (var gr in groups)
                        {
                            if (gr.Type == type)
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                        }
                        break;

                    case "4":
                        foreach (var gr in groups)
                        {
                            if(gr.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }

                        break;

                    case "5":
                        
                        foreach (var gr in groups)
                        {

                            var diff = DateTime.Now - gr.StartDate;
                            if ( diff.TotalDays == 60  )

                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }

                        break;

                    case "6":
                        string LastDaystr;
                        Console.WriteLine("Ayin son gunun qeyd edin:");
                        LastDaystr = Console.ReadLine();
                        DateTime LastDay = Convert.ToDateTime(LastDaystr);

                        foreach (var gr in groups)
                        {
                            if(gr.StartDate>= DateTime.Now && gr.StartDate<=LastDay)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }

                        }

                        break;

                    case "7":

                        string FirstDatestr;
                        Console.WriteLine("Tarix qeyd edin:");
                        FirstDatestr = Console.ReadLine();
                        DateTime FirstDate = Convert.ToDateTime(FirstDatestr);


                        string SecondDatestr;
                        Console.WriteLine("Tarix qeyd edin:");
                        SecondDatestr = Console.ReadLine();
                        DateTime SecondDate = Convert.ToDateTime(SecondDatestr);

                        foreach (var gr in groups)
                        {
                            if(gr.StartDate > FirstDate && gr.StartDate< SecondDate)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                            }
                        }
                        break;

                    case "0":
                        Console.WriteLine("Proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("Seciminiz yanlisdir");
                        break;
                }

            } while (opt!="0");



        }
    }
}
