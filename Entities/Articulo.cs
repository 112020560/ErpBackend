using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    public class Articulo
    {
        public int pk_producto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precio_venta { get; set; }
        public int descuento { get; set; }
        public int descuento_maximo { get; set; }
        public decimal iva { get; set; }
    }

    public class ArticuloBusquedaAvanzada
    {
        [JsonProperty("pk_inv_mtr_producto")] public int pk_inv_mtr_producto { get; set; }
        [JsonProperty("fk_cat_pais")] public int fk_cat_pais { get; set; }
        [JsonProperty("fk_cat_compania")] public int fk_cat_compania { get; set; }
        [JsonProperty("fk_cat_marca")] public int fk_cat_marca { get; set; }
        [JsonProperty("marca")] public string marca { get; set; }
        [JsonProperty("fk_cat_linia")] public int fk_cat_linia { get; set; }
        [JsonProperty("linea")] public string linea { get; set; }
        [JsonProperty("fk_cat_modelo")] public int fk_cat_modelo { get; set; }
        [JsonProperty("modelo")] public string modelo { get; set; }
        [JsonProperty("fk_cat_clasificacion")] public int fk_cat_clasificacion { get; set; }
        [JsonProperty("codigo_producto")] public string codigo_producto { get; set; }
        [JsonProperty("codigo_barra")] public string codigo_barra { get; set; }
        [JsonProperty("serie")] public string serie { get; set; }
        [JsonProperty("descripcion1")] public string descripcion1 { get; set; }
        [JsonProperty("descripcion2")] public string descripcion2 { get; set; }
        [JsonProperty("descripcion3")] public string descripcion3 { get; set; }
        [JsonProperty("costo")] public decimal costo { get; set; }
        [JsonProperty("utilidad")] public decimal utilidad { get; set; }
        [JsonProperty("precio_venta")] public decimal precio_venta { get; set; }
        [JsonProperty("descuento_maximo")] public decimal descuento_maximo { get; set; }
        [JsonProperty("se_puede_vender")] public short se_puede_vender { get; set; }
        [JsonProperty("se_puede_comprar")] public short se_puede_comprar { get; set; }
        [JsonProperty("es_consignacion")] public short es_consignacion { get; set; }
        [JsonProperty("cantidad")] public int cantidad { get; set; }
        [JsonProperty("cantidad_bloqueda")] public int cantidad_bloqueda { get; set; }
    }
}
