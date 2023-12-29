using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Dtos.Masterbarang
{
    public class MasterbarangOptionDto
    {
        public short? BrgKode { get; set; }
        public string BrgNama { get; set; } = null!;
    }


    public class MasterbarangOptionWithTipeDto : MasterbarangOptionDto
    {
        public CommonResultDto Mastertipebarang { get; set; }
    }

    public class MasterbarangOptionWithSnDto : MasterbarangOptionDto
    {
        public bool Sn { get; set; }
        public int JurnalBiaya { get; set; }
        public sbyte Shownya { get; set; }

    }

}
