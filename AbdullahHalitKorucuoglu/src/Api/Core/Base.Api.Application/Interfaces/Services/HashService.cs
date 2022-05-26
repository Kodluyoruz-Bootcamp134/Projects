using HashidsNet;

namespace Base.Api.Application.Interfaces.Services;

public class HashService
{
    private readonly Hashids _hashids;

    public HashService()
    {
        _hashids = new Hashids("my_saltkey", 8);
    }

    public string Encode(int id)
    {
        return _hashids.Encode(id);
    }

    public int Decode(string key)
    {
        if (_hashids.TryDecodeSingle(key, out int number))
        {
            return number;
        }

        return 0;
    }
}