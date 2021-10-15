using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Parser
    {
        private string input;
        private char[] arrInput;

        public decimal leftOperand;
        public decimal rightOperand;
        public char operat;
        public decimal result;

        public bool stop = false;
        private int countOperat = 0;

        private void Input()
        {
            input = Console.ReadLine();
            input = input
                .Replace(" ", "")
                .Replace(",", ".")
                .Replace("=", "");
            arrInput = input.ToCharArray();

            CountAllOperat();
        }

        public void CountAllOperat()
        {
            foreach (var t in arrInput)
            {
                if (t == '-' || t == '+' || t == '*' || t == '/')
                {
                    countOperat++;
                }
            }
        }
        private static decimal ParseDecimal(string s)
        {
            return decimal.Parse(
                s,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture
            );
        }

        private bool OperatorFind()
        {
            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == '+' || arrInput[i] == '-' || arrInput[i] == '*' || arrInput[i] == '/')
                    {
                        operat = arrInput[i];
                        return true;
                    }
                }
            }

            return false;
        }

        private void ParseLeftOperand()
        {
            string firstOperand = "";
            OperatorFind();

            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            firstOperand += arrInput[j];
                        }
                    }
                }

                if (OperatorFind() == false)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        firstOperand += arrInput[i];
                    }
                }
            }

            if (firstOperand != "")
            {
                try
                {
                    leftOperand = ParseDecimal(firstOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Перше число введено не правильно");
                    stop = true;
                }
            }
        }

        private void ParseRightOperand()
        {
            string secondOperand = "";
            bool o = false;
            if (OperatorFind() == false)  // если знак операции еще не введен
            {
                Input();
                OperatorFind();
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        o = true;
                    }
                }
                if (OperatorFind() == true && o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == operat)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "" && OperatorFind() == true)
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }
            else if (OperatorFind() == true)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == operat)
                    {
                        o = true;
                    }
                }

                if (o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == operat)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "")
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }


            if (secondOperand != "")
            {
                try
                {
                    rightOperand = ParseDecimal(secondOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Друге число введено не правильно");
                    stop = true;
                }
            }

        }

        public void Parse()
        {
            Input();
            ParseLeftOperand();
            ParseRightOperand();
        }

        public void CalcResult()
        {
            if (countOperat > 1)
            {
                Console.WriteLine("Більше одного знака дії.");
                stop = true;
            }

            if (stop == false)
            {
                Calculate();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{leftOperand} {operat} {rightOperand} = {result}");
                Console.ResetColor();

                countOperat = 0;
            }
        }

        public void Calculate() { }

        class ApplicationLicense
        {
            public enum LicenseTypes
            {
                Common = 0,
                Trial,
                Pro
            }

            private string TrialKey = "VK7JG-NPHTM-C97JM-9MPGT-3V66T";
            private string ProKey = "7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH";

            public LicenseTypes License
            {
                get;
                set;
            }

            public LicenseTypes DefineLicense(string key)
            {
                if (key == TrialKey)
                {
                    AllowTrial();
                }
                else if (key == ProKey)
                {
                    AllowPro();
                }
                else
                {
                    AllowCommon();
                }

                return License;
            }

            public void AllowCommon()
            {
                License = LicenseTypes.Common;
            }

            public void AllowTrial()
            {
                License = LicenseTypes.Trial;
            }
            public void AllowPro()
            {
                License = LicenseTypes.Pro;
            }
        }

        class Common : Parser
        {
            public void Instruction()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У Вас безкоштовна версія");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Інструкція: ");
                Console.WriteLine();
                Console.WriteLine("Введіть математичний приклад, який складається з двух чисел і знаком дії між цими числами.");
                Console.WriteLine("Приклад може бути введений частинами.");
                Console.WriteLine("Пробіли та знаки рівності ігноруються.");
                Console.WriteLine();
                Console.WriteLine("Можливі операції над числами: \nДодавання (+), \nВіднімання (-).");
                Console.WriteLine("Кількість доступних введеннь прикладів без перезапуску програми: 1");
                Console.WriteLine();
                Console.WriteLine();
            }

            public new void Calculate()
            {
                switch (operat)
                {
                    case '+':
                        result = leftOperand + rightOperand;
                        break;
                    case '-':
                        result = leftOperand - rightOperand;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Операція не доступна для безкоштовної версії");
                        Console.ResetColor();
                        stop = true;
                        break;
                }
            }

            public Common()
            {
                Instruction();
                Console.Write("\n↓↓↓\n");
                Parse();
                Calculate();
                CalcResult();
            }
        }


        class Pro : Parser
        {
            public void Instruction()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("У Вас Pro версія");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Інструкція: ");
                Console.WriteLine("Введіть математичний приклад, який складається з двух чисел і знаком дії між цими числами.");
                Console.WriteLine("Приклад може бути введений частинами.");
                Console.WriteLine("Пробіли та знаки рівності ігноруються.");
                Console.WriteLine();
                Console.WriteLine("Можливі операції над числами: \nДодавання (+), \nВіднімання (-), \nМноження (*), \nДілення (/).");
                Console.WriteLine("Кількість доступних введеннь прикладів без перезапуску програми: НЕОБМЕЖЕНО");
                Console.WriteLine();
            }

            public new void Calculate()
            {
                switch (operat)
                {
                    case '+':
                        result = leftOperand + rightOperand;
                        break;
                    case '-':
                        result = leftOperand - rightOperand;
                        break;
                    case '*':
                        result = leftOperand * rightOperand;
                        break;
                    case '/':
                        result = leftOperand / rightOperand;
                        break;
                }
            }

            public Pro()
            {
                Instruction();
                do
                {
                    Console.Write("\n↓↓↓\n");
                    Parse();
                    Calculate();
                    CalcResult();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\n\t--Натисніть \"Enter\" для продовження, або \"Esc\", щоб завершити--");
                    Console.ResetColor();
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }


        class Trial : Parser
        {
            public void Instruction()
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("У Вас триальний режим");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Інструкція: ");
                Console.WriteLine();
                Console.WriteLine("Введіть математичний приклад, який складається з двух чисел і знаком дії між цими числами.");
                Console.WriteLine("Приклад може бути введений частинами.");
                Console.WriteLine("Пробіли та знаки рівності ігноруються.");
                Console.WriteLine();
                Console.WriteLine("Можливі операції над числами: \nДодавання (+), \nВіднімання (-), \nМноження (*), \nДілення (/).");
                Console.WriteLine("Кількість доступних введеннь прикладів без перезапуску програми: 1");
                Console.WriteLine();
                Console.WriteLine();
            }

            public new void Calculate()
            {
                switch (operat)
                {
                    case '+':
                        result = leftOperand + rightOperand;
                        break;
                    case '-':
                        result = leftOperand - rightOperand;
                        break;
                    case '*':
                        result = leftOperand * rightOperand;
                        break;
                    case '/':
                        result = leftOperand / rightOperand;
                        break;
                }
            }

            public Trial()
            {
                Instruction();
                Console.Write("\n↓↓↓\n");
                Parse();
                Calculate();
                CalcResult();
            }
        }



        class Program
        {
            static void Main(string[] args)
            {
                Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;

                ApplicationLicense license = new ApplicationLicense();

                Console.Write("Введіть ключ ліцензії: ");
                license.DefineLicense(Console.ReadLine());

                if (license.License == ApplicationLicense.LicenseTypes.Pro)
                {
                    Pro pro = new Pro();

                }
                else if (license.License == ApplicationLicense.LicenseTypes.Trial)
                {
                    Trial trial = new Trial();
                }
                else if (license.License == ApplicationLicense.LicenseTypes.Common)
                {
                    Common common = new Common();
                }
            }
        }
    }
}
