using System;

namespace Models
{
    public class Book
    {
        public string Name{get;set;}
        public string Author{get;set;}
        public string? Price{get;set;}
        public bool? IsBestSeller{get;set;}
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Book p = (Book) obj;
                return (Name == p.Name) && (Author == p.Author) && (Price == p.Price) && (IsBestSeller == p.IsBestSeller);
            }
        }
    }
}