using System;

namespace Uri1246
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string[] testCase = firstLine.Split(' ');
            int meters = Convert.ToInt32(testCase[0]);
            int events = Convert.ToInt32(testCase[1]);
            int parking = 0;
            int finalValue = 0;
            string[] parksize = new string[meters];
            for (int i = 0; i < meters; i++)
            {
                parksize[i] = " ";
            }
            while (parking < events)
            {
                string otersLines = Console.ReadLine();
                string[] testCars = otersLines.Split(' ');
                string input = testCars[0];
                string plate = testCars[1];
                string[] plates = new string[events];

                if (input == "C" || input == "c") //Logica da Chegada
                {
                    int length = Convert.ToInt32(testCars[2]);
                    bool validPlate = true;
                    bool fixedValue = false;

                    for (int i = 0; i < meters; i++) //elemento validação placa
                    {
                        if (plate == parksize[i])
                        {
                            validPlate = false;
                            break;
                        }
                    }
                    if (validPlate == true)
                    {
                        for (int i = 0; i < meters; i++) //elemento verificação espaço
                        {
                            if (parksize[i] == " ")
                            {
                                int lot = i;
                                int lengthPark = 0;
                                for (int x = i; x < meters; x++)
                                {
                                    if (parksize[x] == " ")
                                    {
                                        lengthPark += 1;
                                    }
                                    else
                                    {
                                        lengthPark = 0;
                                    }
                                    if (lengthPark >= length)
                                    {
                                        lot = i;
                                        for (int p = 0; p < length; p++)
                                        {
                                            parksize[lot] = plate;
                                            lot++;
                                        }
                                        fixedValue = true;
                                    }
                                }
                                break;
                            }
                        }
                        if (fixedValue == true)
                        {
                            finalValue += 10;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (input == "S" || input == "s") //logica da saida
                {
                    for (int i = 0; i < meters; i++)
                    {
                        if (plate == parksize[i])
                        {
                            parksize[i] = " ";
                        }
                    }
                }
                else //entrada invalida
                {
                    Console.WriteLine("invalid input");
                }
                parking += 1;
            }
            Console.WriteLine(finalValue);
            Console.ReadLine();
        }
    }
}
