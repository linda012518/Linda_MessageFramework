using Common;
using System.Collections.Generic;

public partial class AreaCode : LYDEnum
{
    public static AreaCode None = new AreaCode(0, "None");

    static Dictionary<string, AreaCode> _nameDic;
    static Dictionary<int, AreaCode> _indexDic;

    private AreaCode(int value, string name) : base(value, name)
    {
        if (_nameDic == null)
            _nameDic = new Dictionary<string, AreaCode>();
        if (_indexDic == null)
            _indexDic = new Dictionary<int, AreaCode>();

        _nameDic.Add(name, this);
        _indexDic.Add(value, this);
    }

    public static implicit operator AreaCode(int index)
    {
        if (_indexDic.ContainsKey(index))
            return _indexDic[index];
        return null;
    }

    public static explicit operator AreaCode(string name)
    {
        if (_nameDic.ContainsKey(name))
            return _nameDic[name];
        return null;
    }

}

