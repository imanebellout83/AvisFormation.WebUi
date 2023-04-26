using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvisFormation.WebUi.Models
{
    public class MyViewModel
    {
        public MyViewModel()
        {
        }

        public string Message { get;  set; }
        public List<string> Ville { get; set; }
        [Required]
        public bool mycheckbox1 { get; set; }
        public string label1 { get; set; }
        [DisplayName("ma chaine de caractaire:")]
        [EmailAddress ]
        public string mystring { get; set; }
        //dropdown list
        public Gender FormationGender { get; set; }
        

    }
    


}