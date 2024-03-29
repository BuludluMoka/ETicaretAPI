﻿public enum ResultInfo
{
    Success = 200,

    //--- Success --- (starts with 1)
    SaveSuccess = 1000,
    Deleted = 1001,
    //-------------------------------

    //--- Fail --- (starts with 2)
    SaveFailure = 2000,
    NotFound = 2002,
    UserNamePasswordIncorrect = 2003,
    TokenExpired = 2004,
    TokenIsInvalid = 2005,
    UnexpectedError = 2006,
    InternalServerError = 2007,
    Unauthorized = 2008,
    FillRequiredFields = 2009,
    CannotBeChanged = 2012,
    InvalidRequestParameters = 2013,
    ConfirmPasswordError = 2015,
    AlreadyExists = 2016,
    UserNameAlreadyExists = 2017,
    EmailAlreadyExists = 2018,
    OrderHasCalculationSheet = 2020,
    PasswordValidation = 2021,
    OldPasswordError = 2022,
    FileFormatIncorrect = 2024,

    //-------------------------------

    //--- Warning --- (starts with 3)
    EndedWithWarning = 3000,
    //-------------------------------

    NotImplemented = -1
}
