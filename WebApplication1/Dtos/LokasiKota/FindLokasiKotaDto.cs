﻿using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.LokasiKota
{
    
    public class FindLokasiKotaDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Nama { get; set; }

        [SwaggerSchema(Description = "Cari by aktif")]
        public bool? Aktif { get; set; }
    }
}
