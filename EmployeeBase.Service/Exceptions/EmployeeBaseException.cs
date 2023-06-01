using System;

namespace EmployeeBase.Service.Exceptions
{
    public class EmployeeBaseException : Exception
    {
        public int Code { get; set; }
        public EmployeeBaseException(int code, string massage) : base(massage)
        {
            Code = code;
        }
    }
}
