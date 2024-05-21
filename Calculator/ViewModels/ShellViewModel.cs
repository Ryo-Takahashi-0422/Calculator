using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.Screen
    {
		private decimal _num = 0;

		public decimal Num
		{
			get 
			{
				return _num; 
			}
			set 
			{
                _num = value;
				NotifyOfPropertyChange(() => Num);
			}
		}

		/// <summary>
		/// [1]ボタンが入力された時の処理
		/// </summary>
		public void PushButtonOne()
		{
			string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
			{
                Num = decimal.Parse(tempNum + "1");
            }            
        }

        /// <summary>
        /// [2]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonTwo()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "2");
            }
        }

        /// <summary>
        /// [3]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonThree()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "3");
            }
        }

        /// <summary>
        /// [4]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFour()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "4");
            }
        }

        /// <summary>
        /// [5]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFive()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "5");
            }
        }

        /// <summary>
        /// [6]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSix()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "6");
            }
        }

        /// <summary>
        /// [7]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSeven()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "7");
            }
        }

        /// <summary>
        /// [8]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonEight()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "8");
            }
        }

        /// <summary>
        /// [9]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonNine()
        {
            string tempNum = Num.ToString();

            if (CheckCurrentNumLenght(tempNum))
            {
                Num = decimal.Parse(tempNum + "9");
            }
        }

        /// <summary>
        /// [AC]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonAC()
        {
            Num = 0;
        }

        /// <summary>
        /// 現在の入力値が20桁未満かチェックする。未満ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckCurrentNumLenght(string target)
		{
			if (target.Length < 20)
			{
				return true;
			}

			return false;
		}
	}
}
