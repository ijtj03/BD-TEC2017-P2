//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto2DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personas()
        {
            this.cajasxpersonas = new HashSet<cajasxpersonas>();
            this.facturasxpersonas = new HashSet<facturasxpersonas>();
            this.personasxdistritos = new HashSet<personasxdistritos>();
            this.personasxsucursales = new HashSet<personasxsucursales>();
            this.rolesxpersonas = new HashSet<rolesxpersonas>();
        }
    
        public int idcedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int telefono { get; set; }
        public int iddireccion { get; set; }
        public System.DateTime fechanacimiento { get; set; }
        public bool logicdelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cajasxpersonas> cajasxpersonas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<facturasxpersonas> facturasxpersonas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personasxdistritos> personasxdistritos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personasxsucursales> personasxsucursales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rolesxpersonas> rolesxpersonas { get; set; }
    }
}
