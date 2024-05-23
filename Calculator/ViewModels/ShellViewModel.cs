using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculator.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.Screen
    {
        /// <summary>
        /// 表記のプライベート値
        /// </summary>
		private decimal _num = 0;

        /// <summary>
        /// 演算対象1つ目の入力
        /// </summary>
        private decimal firstInputNum;

        /// <summary>
        /// 演算対象2つ目の入力
        /// </summary>
        private decimal secondInputNum;

        /// <summary>
        /// 最大値
        /// </summary>
        private decimal maxNum = 100000000000000000000M;

        /// <summary>
        /// 最小値
        /// </summary>
        private decimal minNum = -10000000000000000000M;

        /// <summary>
        /// メモリー
        /// </summary>
        private decimal mem = 0;

        /// <summary>
        /// 最大桁数
        /// </summary>
        private int maxNumDigit = 20;

        /// <summary>
        /// ドットボタンが押下された状態かどうか
        /// </summary>
        private bool IsDotButtonPushed = false;

        /// <summary>
        /// ドットボタンが押下可能かどうか
        /// </summary>
        private bool dotButtonActive = true;

        /// <summary>
        /// 演算対象2つ目の入力状態かどうか
        /// </summary>
        private bool isSecondInput = false;

        /// <summary>
        /// +,-,x,÷,=押下直後かどうか
        /// </summary>
        private bool isAfterPushMathSymbol = false;

        /// <summary>
        /// MRC押下直後かどうか
        /// </summary>
        private bool isAfterPushMRC = false;
   
        /// <summary>
        /// 演算の状態管理
        /// </summary>
        enum CalculateFlags
        {
            plus = 1,    //0000_0001 "+"
            minus = 2,    //0000_0010 "-"
            multi = 4,    //0000_0100 "x"
            div = 8,    //0000_1000 "÷"
        }
        private CalculateFlags calculateFlags = 0;

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
        /// [0]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonZero()
        {
            // 現在のテキストボックス値が0且つdotボタン非押下状態なら何もしないで早期リターン
            if(CheckCurrentNumIsZero() && !IsDotButtonPushed && dotButtonActive)
            {
                return;
            }

            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 0);
        }

        /// <summary>
        /// [1]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonOne()
		{
			string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 1);
        }

        /// <summary>
        /// [2]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonTwo()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 2);
        }

        /// <summary>
        /// [3]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonThree()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 3);
        }

        /// <summary>
        /// [4]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFour()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 4);
        }

        /// <summary>
        /// [5]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonFive()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 5);
        }

        /// <summary>
        /// [6]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSix()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 6);
        }

        /// <summary>
        /// [7]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonSeven()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 7);
        }

        /// <summary>
        /// [8]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonEight()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 8);
        }

        /// <summary>
        /// [9]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonNine()
        {
            string tempNum = Num.ToString();
            ProcessInputNumButton(tempNum, 9);
        }

        /// <summary>
        /// 数字ボタン(00以外)押下時の共通処理
        /// </summary>
        /// <param name="tempNum">現在表記されている値</param>
        /// <param name="inputNum">ボタンの数値</param>
        private void ProcessInputNumButton(string tempNum, int inputNum)
        {
            string m_Num = inputNum.ToString();

            if (!isSecondInput)
            {
                if (CheckInputNumLenght(tempNum.Length) || tempNum.Length == maxNumDigit)
                {
                    if (IsDotButtonPushed)
                    {
                        firstInputNum = decimal.Parse(tempNum + "." + m_Num);
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号かMRCを押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol || isAfterPushMRC)
                        {
                            secondInputNum = decimal.Parse(m_Num);
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                            isAfterPushMRC = false;
                        }
                        // でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + m_Num);
                            Num = secondInputNum;
                        }
                    }
                }
            }
            else
            {
                if (CheckInputNumLenght(tempNum.Length) || tempNum.Length == maxNumDigit)
                {
                    if (IsDotButtonPushed)
                    {
                        secondInputNum = decimal.Parse(tempNum + "." + m_Num);
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    else
                    {
                        // 数学記号かMRCを押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol || isAfterPushMRC)
                        {
                            secondInputNum = decimal.Parse(m_Num);
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                            isAfterPushMRC = false;
                        }
                        // でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + m_Num);
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// [00]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDoubleZero()
        {
            // 現在のテキストボックス値が0且つdotボタン非押下状態なら何もしないで早期リターン
            if (CheckCurrentNumIsZero() && !IsDotButtonPushed && dotButtonActive)
            {
                return;
            }

            string tempNum = Num.ToString();

            if (!isSecondInput)
            {
                if (IsDotButtonPushed)
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        firstInputNum = decimal.Parse(tempNum + ".0");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        firstInputNum = decimal.Parse(tempNum + ".00");
                        Num = firstInputNum;
                        IsDotButtonPushed = false;
                    }
                }
                else
                {
                    // 数学記号かMRCを押した直後は入力をそのまま表示する
                    if (isAfterPushMathSymbol || isAfterPushMRC)
                    {
                        secondInputNum = decimal.Parse("0");
                        Num = secondInputNum;
                        isAfterPushMathSymbol = false;
                        isAfterPushMRC = false;
                    }
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    else if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        firstInputNum = decimal.Parse(tempNum + "0");
                        Num = firstInputNum;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        firstInputNum = decimal.Parse(tempNum + "00");
                        Num = firstInputNum;
                    }
                }
            }
            else
            {
                if (IsDotButtonPushed)
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        secondInputNum = decimal.Parse(tempNum + ".0");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        secondInputNum = decimal.Parse(tempNum + ".00");
                        Num = secondInputNum;
                        IsDotButtonPushed = false;
                    }
                }
                else
                {
                    // 現在のテキストボックス値桁数が19桁なら0を追加する。
                    if (CheckCurrentNumOfDigitIs_19(tempNum.Length))
                    {
                        secondInputNum = decimal.Parse(tempNum + "0");
                        Num = secondInputNum;
                    }
                    // 現在のテキストボックス値桁数に1を足した結果が20桁未満なら00を追加する。
                    else if (CheckInputNumLenght(tempNum.Length + 1))
                    {
                        // 数学記号かMRCを押した直後は入力をそのまま表示する
                        if (isAfterPushMathSymbol || isAfterPushMRC)
                        {
                            secondInputNum = decimal.Parse("0");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                            isAfterPushMRC = false;
                        }
                        // 数学記号を押した直後は入力をそのまま表示する
                        else if (isAfterPushMathSymbol)
                        {
                            secondInputNum = decimal.Parse("0");
                            Num = secondInputNum;
                            isAfterPushMathSymbol = false;
                        }
                        // 数学記号を押した直後でなければ入力を現在の表記に付け加える
                        else
                        {
                            secondInputNum = decimal.Parse(tempNum + "00");
                            Num = secondInputNum;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// [AC]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonAC()
        {
            Num = 0;
            mem = 0;
            IsDotButtonPushed = false;
            isAfterPushMathSymbol = false;
            isAfterPushMRC = false;
            isSecondInput = false;
            dotButtonActive = true;
        }

        /// <summary>
        /// [C]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonC()
        {
            string temp = Num.ToString();
            int count;

            // 入力値が一桁の場合
            if(temp.Length == 1)
            {
                Num = 0;
                return;
            }

            if (!isSecondInput)
            {
                temp = Num.ToString();
                count = temp.Length;
                temp = temp.Substring(0, count - 1);
                firstInputNum = decimal.Parse(temp);
                Num = firstInputNum;
            }
            else
            {
                temp = Num.ToString();
                count = temp.Length;
                temp = temp.Substring(0, count - 1);
                secondInputNum = decimal.Parse(temp);
                Num = secondInputNum;
            }
        }

        /// <summary>
        /// [M+]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMPlus()
        {
            string tempNum;

            if (isSecondInput)
            {
                if ((calculateFlags & CalculateFlags.plus) == CalculateFlags.plus)
                {
                    mem += firstInputNum + secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.plus;
                }
                else if ((calculateFlags & CalculateFlags.minus) == CalculateFlags.minus)
                {
                    mem += firstInputNum - secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.minus;
                }
                else if ((calculateFlags & CalculateFlags.multi) == CalculateFlags.multi)
                {
                    mem += firstInputNum * secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.multi;
                }
                else if ((calculateFlags & CalculateFlags.div) == CalculateFlags.div)
                {
                    mem += firstInputNum / secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.div;
                }
            }
            else
            {
                mem += Num;
            }

            isSecondInput = false;

            void AdjustResult()
            {
                // 計算結果が最大値より大きい場合、最大値を表示する
                if (mem >= maxNum)
                {
                    mem = maxNum - 1;
                }
                // 計算結果が最小値より小さい場合、最小値を表示する
                else if (mem <= minNum) 
                {
                    mem = minNum + 1;
                }

                int numLength = tempNum.Length;
                // 小数の場合の処理
                if (mem > 0 && mem - Math.Floor(mem) != 0M)
                {
                    if (numLength < maxNumDigit)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else 
                    {
                        tempNum = tempNum.Substring(0, maxNumDigit);
                    }
                    
                    mem = decimal.Parse(tempNum);
                }
                else if (mem < 0 && mem - Math.Ceiling(mem) != 0M)
                {
                    if (numLength < maxNumDigit)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, maxNumDigit);
                    }
                    mem = decimal.Parse(tempNum);
                }
            }
        }

        /// <summary>
        /// [M-]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMMinus()
        {
            string tempNum;

            if (isSecondInput)
            {
                if ((calculateFlags & CalculateFlags.plus) == CalculateFlags.plus)
                {
                    mem -= firstInputNum + secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.plus;
                }
                else if ((calculateFlags & CalculateFlags.minus) == CalculateFlags.minus)
                {
                    mem -= firstInputNum - secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.minus;
                }
                else if ((calculateFlags & CalculateFlags.multi) == CalculateFlags.multi)
                {
                    mem -= firstInputNum * secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.multi;
                }
                else if ((calculateFlags & CalculateFlags.div) == CalculateFlags.div)
                {
                    mem -= firstInputNum / secondInputNum;
                    tempNum = mem.ToString();
                    AdjustResult();

                    firstInputNum = 0;
                    secondInputNum = 0;
                    isAfterPushMathSymbol = true;
                    calculateFlags |= ~CalculateFlags.div;
                }
            }
            else
            {
                mem -= Num;
            }

            isSecondInput = false;

            void AdjustResult()
            {
                // 計算結果が最大値より大きい場合、最大値を表示する
                if (mem >= maxNum)
                {
                    mem = maxNum - 1;
                }
                // 計算結果が最小値より小さい場合、最小値を表示する
                else if (mem <= minNum)
                {
                    mem = minNum + 1;
                }

                int numLength = tempNum.Length;
                // 小数の場合の処理
                if (mem > 0 && mem - Math.Floor(mem) != 0M)
                {
                    if (numLength < maxNumDigit)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, maxNumDigit);
                    }

                    mem = decimal.Parse(tempNum);
                }
                else if (mem < 0 && mem - Math.Ceiling(mem) != 0M)
                {
                    if (numLength < maxNumDigit)
                    {
                        tempNum = tempNum.Substring(0, numLength);
                    }
                    else
                    {
                        tempNum = tempNum.Substring(0, maxNumDigit);
                    }
                    mem = decimal.Parse(tempNum);
                }
            }
        }

        /// <summary>
        /// [MRC]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMRC()
        {
            if(mem == 0M)
            {
                Num = 0;
                mem = 0;
            }
            else
            {
                Num = mem;
            }
            
            firstInputNum = 0;
            secondInputNum = 0;
            isAfterPushMRC = true;
        }

        /// <summary>
        /// [.]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDot()
        {
            if(dotButtonActive)
            {
                IsDotButtonPushed = true;
                dotButtonActive = false; // +とか計算ボタン押下時にアクティベートする
            }       
        }

        /// <summary>
        /// [+]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonPlus()
        {
            firstInputNum = Num;
            calculateFlags &= 0;
            calculateFlags |= CalculateFlags.plus;

            isSecondInput = true;
            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [-]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMinus()
        {
            firstInputNum = Num;
            calculateFlags &= 0;
            calculateFlags |= CalculateFlags.minus;

            isSecondInput = true;
            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [x]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonMulti()
        {
            firstInputNum = Num;
            calculateFlags &= 0;
            calculateFlags |= CalculateFlags.multi;

            isSecondInput = true;
            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [÷]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonDivide()
        {
            firstInputNum = Num;
            calculateFlags &= 0;
            calculateFlags |= CalculateFlags.div;

            isSecondInput = true;
            dotButtonActive = true;
            isAfterPushMathSymbol = true;
        }

        /// <summary>
        /// [=]ボタンが入力された時の処理
        /// </summary>
        public void PushButtonEqual()
        {
            string tempNum;

            if ((calculateFlags & CalculateFlags.plus) == CalculateFlags.plus)
            {
                firstInputNum += secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if ((calculateFlags & CalculateFlags.minus) == CalculateFlags.minus) 
            {
                firstInputNum -= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if ((calculateFlags & CalculateFlags.multi) == CalculateFlags.multi)
            {
                firstInputNum *= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }
            else if ((calculateFlags & CalculateFlags.div) == CalculateFlags.div)
            {
                firstInputNum /= secondInputNum;
                tempNum = firstInputNum.ToString();
                ProcessResult();
            }

            isSecondInput = false;
            dotButtonActive = true;
            isAfterPushMathSymbol = true;

            void ProcessResult()
            {
                // 計算結果の桁数が20以下なら表示する。
                if (CheckCurrentNumLenght(tempNum.Length))
                {
                    Num = firstInputNum;
                }
                // 計算結果が最大値より大きい場合、最大値を表示する
                else if (firstInputNum >= maxNum)
                {
                    Num = maxNum - 1;
                    firstInputNum = Num; // TODO : 1e + ...といった表記にする
                }
                // 計算結果が最小値より小さい場合、最小値を表示する
                else if (firstInputNum <= minNum)
                {
                    Num = minNum + 1;
                    firstInputNum = Num; // TODO : 1e + ...といった表記にする
                }
                else if (firstInputNum > 0 && firstInputNum - Math.Floor(firstInputNum) != 0M)
                {
                    tempNum = tempNum.Substring(0, maxNumDigit);
                    firstInputNum = decimal.Parse(tempNum);
                    Num = firstInputNum;
                }
                else if (firstInputNum < 0 && firstInputNum - Math.Ceiling(firstInputNum) != 0M)
                {
                    tempNum = tempNum.Substring(0, maxNumDigit);
                    firstInputNum = decimal.Parse(tempNum);
                    Num = firstInputNum;
                }
            }
        }

        /// <summary>
        /// 現在の入力値が20桁未満かチェックする。未満ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="length">チェックする桁数</param>
        /// <returns></returns>
        private bool CheckInputNumLenght(int length)
		{
			if (length < maxNumDigit)
			{
				return true;
			}

			return false;
		}

        /// <summary>
        /// 現在の入力値が19桁かチェックする。19桁ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="length">チェックする桁数</param>
        /// <returns></returns>
        private bool CheckCurrentNumOfDigitIs_19(int length)
        {
            if (length == maxNumDigit - 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 計算結果が20桁以下かチェックする。未満ならtrue、以上ならfalseを返す。
        /// </summary>
        /// <param name="length">チェックする桁数</param>
        /// <returns></returns>
        private bool CheckCurrentNumLenght(int length)
        {
            if (length <= maxNumDigit)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 現在のテキストボックス入力値が0かどうか判定する。0ならtrue、でなければfalseを返す。
        /// </summary>
        /// <returns></returns>
        private bool CheckCurrentNumIsZero()
        {
            if(Num == 0)
            {
                return true;
            }

            return false;
        }
	}
}
