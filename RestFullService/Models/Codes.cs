using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFullService.Models
{
    public static class Codes
    {

        public const int LOGIN_FAIL = -7;
        public const int NOT_ALLOWED = -6;
        public const int ALREADY_REGISTERED = -5;
        public const int UNVERIFIED = -4;
        public const int INVALIDREQUEST = -3;
        public const int UNAUTHORIZED = -2;
        public const int SERVERERROR = -1;
        public const int ERROR = 0;
        public const int SUCCESSFULL = 1;
        public const int SUCCESSFULL_DATAREQUIRED = 2;
        public const int REGISTERED = 3;
        public const int VERIFIED = 4;
        public const int ALLOWED = 5;
        public const int LOGED_IN = 6;
    }
}