using System;


namespace AddressBookSonarQube.Core.Exceptions;


public class AddressBookException : Exception
{
    public AddressBookException(string message) : base(message) { }
}