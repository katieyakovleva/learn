//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace learn
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public partial class uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uslugi()
        {
            this.uslugi_client = new HashSet<uslugi_client>();
        }

        public string GetPhoto
        {
            get
            {
                if (Главное_изображение is null)
                    return null;
                return Directory.GetCurrentDirectory() + @"\photo\" + Главное_изображение.Trim();
            }
        }
        public string GetColor
        {
            get
            {
                if (Действующая_скидка > 0)
                    return "#98FB98";
                else
                    return "FFF";
            }
        }
        public string GetVisibility
        {
            get

            {
                if (Действующая_скидка == 0)
                    return "Collapsed";
                else
                    return "Visible";
            }
        }
        public string TotalPrice
        {
            get
            {
                double p = (double)(Стоимость - Стоимость * Действующая_скидка / 100);
                return $"{p.ToString()} рублей  за {Длительность} минут";
            }
        }

        public int код_услуги { get; set; }
        public string Наименование_услуги { get; set; }
        public string Главное_изображение { get; set; }
        public Nullable<int> Длительность { get; set; }
        public Nullable<double> Стоимость { get; set; }
        public Nullable<double> Действующая_скидка { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<uslugi_client> uslugi_client { get; set; }
    }
}
