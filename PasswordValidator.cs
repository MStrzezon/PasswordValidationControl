using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordValidationControl
{
    public partial class PasswordValidator : UserControl
    {
        public PasswordValidator()
        {
            InitializeComponent();
            MinimumNumberOfCharacters = 8;
            specialCharacters = new List<char> { '$', '#', '@', '!', '%' };
        }

        public event EventHandler IsMinimumNumberOfCharactersChanged;
        public event EventHandler IsSpecialCharacterChanged;
        public event EventHandler IsCapitalLetterChanged;
        public event EventHandler IsDigitChanged;
        public event EventHandler ValidPasswordChanged;

        private int minimumNumberOfCharacters;
        private List<char> specialCharacters = new List<char>();

        private bool isMinimumNumberOfCharacters;
        private bool isSpecialCharacter;
        private bool isCapitalLetter;
        private bool isDigit;

        private string password;

        public int MinimumNumberOfCharacters
        {
            get { return minimumNumberOfCharacters; }
            set { minimumNumberOfCharacters = value; label1.Text = "at least " + MinimumNumberOfCharacters + " characters"; }
        }

        public List<char> SpecialCharacters
        {
            get { return specialCharacters; }
            set { specialCharacters = value; }
        }

        public bool IsMinimumNumberOfCharacters { get => isMinimumNumberOfCharacters; }
        public bool IsSpecialCharacter { get => isSpecialCharacter; }
        public bool IsCapitalLetter { get => isCapitalLetter; }
        public bool IsDigit { get => isDigit; }

        public string Password { set
            {
                password = value;
                bool tmpValid = Valid;
                bool tmpIsDigit = false;
                bool tmpIsSpecialCharacter = false;
                bool tmpIsCapitalLetter = false;

                if (password.Length >= MinimumNumberOfCharacters)
                {
                    if (isMinimumNumberOfCharacters == false)
                    {
                        isMinimumNumberOfCharacters = true;
                        IsMinimumNumberOfCharactersChanged(this, null);
                    }
                } else
                {
                    if (isMinimumNumberOfCharacters == true)
                    {
                        isMinimumNumberOfCharacters = false;
                        IsMinimumNumberOfCharactersChanged(this, null);
                    }
                }

                for (int i = 0; i < password.Length; i++)
                {
                    if (Char.IsDigit(password[i]))
                    {
                        tmpIsDigit = true;
                    } 
                    if (Char.IsUpper(password[i]))
                    {
                        tmpIsCapitalLetter = true; 
                    }
                    if (SpecialCharacters.Contains(password[i]))
                    {
                        tmpIsSpecialCharacter = true; 
                    }
                }

                if (isDigit != tmpIsDigit)
                {
                    isDigit = tmpIsDigit;
                    IsDigitChanged(this, null);
                }
                if (isSpecialCharacter != tmpIsSpecialCharacter)
                {
                    isSpecialCharacter = tmpIsSpecialCharacter;
                    IsSpecialCharacterChanged(this, null);
                }
                if (isCapitalLetter != tmpIsCapitalLetter)
                {
                    isCapitalLetter = tmpIsCapitalLetter;
                    IsCapitalLetterChanged(this, null);
                }

                if (Valid != tmpValid)
                {
                    ValidPasswordChanged(this, null);
                }
            } }

        public bool Valid
        {
            get { return isMinimumNumberOfCharacters && isSpecialCharacter && isCapitalLetter && isDigit; }
        }

        public void uncheckMinimumNumberOfCharacters()
        {
            uncheck1Term.Show();
            check1Term.Hide();
        }

        public void checkMinimumNumberOfCharacters()
        {
            uncheck1Term.Hide();
            check1Term.Show();
        }

        public void uncheckSpecialCharacter()
        {
            uncheck2Term.Show();
            check2Term.Hide();
        }

        public void checkSpecialCharacter()
        {
            uncheck2Term.Hide();
            check2Term.Show();
        }

        public void uncheckCapitalLetter()
        {
            uncheck3Term.Show();
            check3Term.Hide();
        }

        public void checkCapitalLetter()
        {
            uncheck3Term.Hide();
            check3Term.Show();
        }

        public void uncheckDigit()
        {
            uncheck4Term.Show();
            check4Term.Hide();
        }

        public void checkDigit()
        {
            uncheck4Term.Hide();
            check4Term.Show();
        }
    }
}
