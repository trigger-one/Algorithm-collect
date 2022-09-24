using System;
public class DivNumber {
    int result;
    public DivNumber () {
        result = 0;
    }
    public void division (int x, int y) {
        if (y == 0) {
            throw (new Exception ("Zero Temperature found"));
        } else {
            result = x / y;
            Console.Write ("result:{0}", result);
        }
        /* try {
            result = x / y;
        } catch (DivideByZeroException e) {
            Console.WriteLine ("Exception caught:{0}", e);
        } finally {
            Console.WriteLine ("Result:{0}", result);
        } */
    }
}
/// <summary>
/// 用户自定义异常
/// </summary>
public class Exception : ApplicationException {
    public Exception (string message) : base (message) { }
}