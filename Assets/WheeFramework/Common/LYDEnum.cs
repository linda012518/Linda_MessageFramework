using System;

namespace Common
{
    public class LYDEnum
    {
        int _index;
        string _name;

        protected LYDEnum(int value, string name)
        {
            _index = value;
            _name = name;
        }

        public static explicit operator string(LYDEnum payment)
        {
            return payment._name;
        }

        public static implicit operator int(LYDEnum payment)
        {
            return payment._index;
        }

        public static bool operator ==(LYDEnum lhs, LYDEnum rhs)
        {
            return lhs._index == rhs._index && lhs._name == rhs._name;
        }

        public static bool operator !=(LYDEnum lhs, LYDEnum rhs)
        {
            return lhs._index != rhs._index || lhs._name != rhs._name;
        }

        public override bool Equals(object obj)
        {
            return obj is LYDEnum @enum && _index == @enum._index && _name == @enum._name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_index, _name);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}