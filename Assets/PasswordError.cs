using UnityEngine;
using TMPro; // Add TextMeshPro namespace

public class PasswordError : MonoBehaviour
{
    // References to TextMeshPro elements
    public TMP_InputField passwordInputField;
    public TMP_Text errorText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        errorText.text = ""; // Initialize error text to empty
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to validate password on button click
    public void ValidatePassword()
    {
        string password = passwordInputField.text;
        string errorMessage = CheckPasswordErrors(password);
        
        // Display error or clear the text
        errorText.text = errorMessage;
    }

    // Check all password requirements and return error message
    private string CheckPasswordErrors(string password)
    {
        // Check if password is too short (less than 8 characters)
        if (password.Length < 8)
            return "The password is too short!";

        // Check if password is too long (more than 20 characters)
        if (password.Length > 16)
            return "The password is too long!";

        // Must contain a lowercase letter
        bool hasLowercase = false;
        foreach (char c in password)
        {
            if (char.IsLower(c))
            {
                hasLowercase = true;
                break;
            }
        }
        if (!hasLowercase)
            return "Must contain a lowercase letter";

        // Must contain an uppercase letter
        bool hasUppercase = false;
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUppercase = true;
                break;
            }
        }
        if (!hasUppercase)
            return "Must contain an uppercase letter";

        // Must contain a number
        bool hasNumber = false;
        int digitSum = 0;
        foreach (char c in password)
        {
            if (char.IsDigit(c))
            {
                hasNumber = true;
                digitSum += (c - '0'); // Add digit value to sum
            }
        }
        if (!hasNumber)
            return "Must contain a number";

        // The digits must add up to 25
        if (digitSum != 25)
            return "The digits must add up to 25";

        // Must contain a special character
        string specialChars = "!@#$%^&*()-_=+[]{}\\|;:'\",.<>/?";
        bool hasSpecialChar = false;
        foreach (char c in password)
        {
            if (specialChars.Contains(c.ToString()))
            {
                hasSpecialChar = true;
                break;
            }
        }
        if (!hasSpecialChar)
            return "Must contain a special character (e.g., !@#)";

        // Cannot contain the letter E (both uppercase and lowercase)
        if (password.Contains("E") || password.Contains("e"))
            return "Cannot contain the letter E";

        // Must contain a month of the year
        string[] months = new string[] { "january", "february", "march", "april", "may", "june", 
                                        "july", "august", "september", "october", "november", "december" };
        bool hasMonth = false;
        foreach (string month in months)
        {
            if (password.ToLower().Contains(month))
            {
                hasMonth = true;
                break;
            }
        }
        if (!hasMonth)
            return "Must contain a month of the year";

        // Must contain the length of your password
        bool containsLength = false;
        string lengthStr = password.Length.ToString();
        if (password.Contains(lengthStr))
            containsLength = true;
        if (!containsLength)
            return "Must contain the length of your password";

        // Must not include any vowels in the first half of the password
        int halfLength = password.Length / 2;
        string firstHalf = password.Substring(0, halfLength);
        string vowels = "aeiouAEIOU";
        foreach (char c in firstHalf)
        {
            if (vowels.Contains(c.ToString()))
            {
                return "Must not include any vowels in the first half of the password";
            }
        }

        // All requirements passed, return empty string
        return "";
    }
}
