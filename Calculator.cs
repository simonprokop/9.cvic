using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.cviceni
{
	class Calculator
	{
		public string Memory
		{
			get;
			set;
		}

		public string Display
		{
			get;
			set;
		}

		string Operation;
		string Number;
		string UsedNumber;
		string Number1;
		string Number2;

		private enum Status
		{
			FirstNumber = 0,
			Operations = 1,
			SecondNumber = 2,
			Result = 3,
			Memory = 4,
			Display = 5
		}

		private Status status = Status.FirstNumber;

		public void ButtonClicked(string A)
		{
			switch (A)
			{
				//Numbers
				case "0":
					Number = "0";
					break;
				case "1":
					Number = "1";
					break;
				case "2":
					Number = "2";
					break;
				case "3":
					Number = "3";
					break;
				case "4":
					Number = "4";
					break;
				case "5":
					Number = "5";
					break;
				case "6":
					Number = "6";
					break;
				case "7":
					Number = "7";
					break;
				case "8":
					Number = "8";
					break;
				case "9":
					Number = "9";
					break;
				case ",":
					Number += ",";
					break;


				//Operations
				case "+":
				case "-":
				case "/":
				case "*":
					Operation = A;
					Number = "";
					status = Status.Operations;
					break;

				case "+-":
					UsedNumber = Convert.ToString(Convert.ToDouble(UsedNumber) * -1);
					if (UsedNumber == "0")
					{
						throw new Exception("Nelze invertovat nulu.");
					}
					if (status == Status.FirstNumber)
					{
						Display = UsedNumber;
						Number1 = UsedNumber;
						status = Status.Display;
					};
					break;

				case "CE":
					if (Number1.Length > 0 && Number2.Length == 0)
					{
						Number1 = "";
						Display = Number1;
					}
					if (Number2.Length > 0)
					{
						Number2 = "";
						Display = Number1;
					}
					if (Number2.Length == 0)
					{
						UsedNumber = "";
					}
					if (Display == "")
					{
						UsedNumber = "";
					}
					status = Status.Display;
					break;

				case "C":
					UsedNumber = "";
					Number1 = "";
					Number2 = "";
					Number = "";
					Operation = "";
					Display = "";
					status = Status.FirstNumber;
					break;


				case "M+":

					Number = Convert.ToString(Convert.ToDouble(Number) + Convert.ToDouble(Memory));
					Display = Number;
					status = Status.Memory;
					break;

				case "M-":
					Number = Convert.ToString(Convert.ToDouble(Number) - Convert.ToDouble(Memory));
					Display = Number;
					status = Status.Memory;
					break;

				case "MC":
					Memory = "";
					status = Status.FirstNumber;
					break;

				case "MR":
					Display = Memory;
					status = Status.Memory;
					break;

				case "MS":
					Memory = UsedNumber;
					status = Status.Memory;
					break;

				case "←":
					if (string.IsNullOrEmpty(Number))
					{
						UsedNumber = UsedNumber.Substring(0, UsedNumber.Length - 1);

						Display = UsedNumber;
						status = Status.Display;
					}
					break;

				case "=":
					status = Status.Result;
					break;


			}

			switch (status)
			{
				case Status.FirstNumber:
					UsedNumber += Number;
					Number1 = UsedNumber;
					Display = Number1;
					break;

				case Status.SecondNumber:
					UsedNumber += Number;
					Number2 += Number;
					Display = UsedNumber;
					break;

				case Status.Operations:
					UsedNumber += Operation;
					Display += Operation;
					status = Status.SecondNumber;
					break;

				case Status.Result:
					Display = Answer();
					UsedNumber = Answer();
					break;

				case Status.Memory:
					Memory = Memory;
					break;

				case Status.Display:
					Display = Display;
					status = Status.FirstNumber;
					break;

			}


			string Answer()
			{

				var first = Convert.ToDouble(Number1);
				var second = Convert.ToDouble(Number2);
				double answer = 0;

				switch (Operation)
				{
					case "+":
						answer = first + second;
						break;

					case "-":
						answer = first - second;
						break;
					case "*":
						answer = first * second;
						break;
					case "/":
						if (second == 0)
						{
							throw new Exception("Not allowed to dividing by zero!");
						}
						answer = first / second;
						break;


				}

				return answer.ToString();
			}

		}


	}
}
