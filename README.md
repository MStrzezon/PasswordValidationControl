# Password Validation Control
It is .NET Framework control, which is used to validating password. <br/> <br/>
![image](https://user-images.githubusercontent.com/72666064/170302432-badc15cf-07de-4167-a3e1-aa820a84b9d5.png)

## Release Notes
### Events
It generates an event when the password status has changed depending on the condition:
+ IsCapitalLetterChanged - capital letter in password
+ IsDigitChanged - digit in password
+ IsMinimumNumberOfCharacters - number of characters in password
+ IsSpecialCharacterChanged - special character  in password
+ ValidPasswordChanged - all requirements 


The minimum number of characters required and the special characters are modifiable.

### Methods
Requirement visualization can be changed using:
+ checkMinimumNumberOfCharacters() / uncheckMinimumNumberOfCharacters()
+ checkCapitalLetter() / uncheckCapitalLetter()
+ checkDigit() / uncheckDigit()
+ checkSpecialCharacter() / uncheckSpecialCharacter()

### Compile or download .dll
You can compile project using VisualStudio or download .dll
