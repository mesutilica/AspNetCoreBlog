﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCoreBlog.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50), Required(ErrorMessage = "Bu alan gereklidir!")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; } // Description kolonunun nullable yani boş geçilebilir olması için ? işareti koyduk
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn attribute ü View larda CreateDate alanı için crud sayfalarında veri giriş alanı oluşmamasını sağlar.
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
