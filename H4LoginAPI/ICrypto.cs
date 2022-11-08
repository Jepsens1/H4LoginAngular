namespace H4LoginAPI
{
    public interface ICrypto
    {
        byte[] GenerateSalt();
        byte[] CreateHash(string password, byte[] salt);
        bool Verify(string passwordfromdb, string passwordprovided, byte[] salt);
    }
}
