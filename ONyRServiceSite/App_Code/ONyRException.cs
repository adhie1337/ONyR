using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public enum ErrorCode
{
    DatabaseError=0,
    NoSessionError,
    InvalidSessionError,
    UnknownError,
    ModifyConflict,
    InvalidCredentialsError
}

/// <summary>
/// Summary description for ONyRException
/// </summary>
public class ONyRException : Exception
{
    private ErrorCode mCode;

	public ONyRException(ErrorCode pCode)
	{
        mCode = pCode;
	}

    public ErrorCode ErrorCode
    {
        get
        {
            return mCode;
        }
    }
}