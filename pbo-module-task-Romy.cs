using System;

// KELAS KARYAWAN
class Karyawan
{
    public string nama;
    public double gaji;

    public Karyawan(string Nama, double Gaji)
    {
        nama = Nama;
        gaji = Gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{nama} tengah menjalankan tugasnya.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama       : {nama}");
        Console.WriteLine($"Gaji Pokok : Rp {gaji:N0}");
    }
}

// KELAS TETAP (mewarisi Karyawan)
class Tetap : Karyawan
{
    public double tunjangan;

    public Tetap(string Nama, double Gaji, double Tunjangan)
        : base(Nama, Gaji)
    {
        tunjangan = Tunjangan;
    }

    public double HitungGajiTotal()
    {
        return gaji + tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} aktif bekerja dengan status karyawan tetap.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Tunjangan  : Rp {tunjangan:N0}");
        Console.WriteLine($"Total Gaji : Rp {HitungGajiTotal():N0}");
    }
}

// KELAS KONTRAK (mewarisi Karyawan)
class Kontrak : Karyawan
{
    public int durasi; // dalam bulan

    public Kontrak(string Nama, double Gaji, int Durasi)
        : base(Nama, Gaji)
    {
        durasi = Durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"Masa kontrak {nama} adalah {durasi} bulan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} menjalankan pekerjaan berdasarkan kontrak yang berlaku.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Lama Kontrak : {durasi} bulan");
    }
}

// KELAS MANAGER (mewarisi Tetap)
class Manager : Tetap
{
    public Manager(string Nama, double Gaji, double Tunjangan)
        : base(Nama, Gaji, Tunjangan)
    {
    }

    public void Memimpin()
    {
        Console.WriteLine($"{nama} sedang mengarahkan jalannya rapat bersama tim.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} mengemban peran sebagai Manager dalam mengelola strategi dan sumber daya tim.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("=== DATA MANAGER ===");
        base.InfoKaryawan();
    }
}

// KELAS STAFF (mewarisi Tetap)
class Staff : Tetap
{
    public Staff(string Nama, double Gaji, double Tunjangan)
        : base(Nama, Gaji, Tunjangan)
    {
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{nama} sedang menyelesaikan pekerjaan rutinnya hari ini.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} bertugas sebagai Staff dalam mendukung kegiatan operasional perusahaan.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("=== DATA STAFF ===");
        base.InfoKaryawan();
    }
}

// KELAS MAGANG (mewarisi Kontrak)
class Magang : Kontrak
{
    public Magang(string Nama, double Gaji, int Durasi)
        : base(Nama, Gaji, Durasi)
    {
    }

    public void Belajar()
    {
        Console.WriteLine($"{nama} aktif mengikuti program magang sambil mengembangkan kemampuannya.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} menjalani program magang dengan berkontribusi langsung kepada tim.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("=== DATA MAGANG ===");
        base.InfoKaryawan();
    }
}

// KELAS FREELANCER (mewarisi Kontrak)
class Freelancer : Kontrak
{
    public Freelancer(string Nama, double Gaji, int Durasi)
        : base(Nama, Gaji, Durasi)
    {
    }

    public void AmbilProyek()
    {
        Console.WriteLine($"{nama} baru saja menerima proyek baru untuk dikerjakan secara lepas.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{nama} bekerja secara mandiri sebagai Freelancer pada proyek yang diterima.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("=== DATA FREELANCER ===");
        base.InfoKaryawan();
    }
}

// KELAS PERUSAHAAN
class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"[+] {karyawan.nama} telah terdaftar sebagai bagian dari perusahaan.");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("      DATA SELURUH KARYAWAN");
        Console.WriteLine("========================================");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
            Console.WriteLine("----------------------------------------");
        }
    }
}

// MAIN PROGRAM
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // --- Buat objek Perusahaan ---
        Perusahaan perusahaan = new Perusahaan();

        // --- Buat objek Karyawan ---
        Manager manager = new Manager("Romy Pratama Putra", 25000000, 5000000);
        Staff staff = new Staff("Budi Hartono", 10000000, 4000000);
        Magang magang = new Magang("Suliono", 5000000, 4);
        Freelancer freelancer = new Freelancer("Kartono Putra", 8000000, 8);

        // --- Tambahkan ke Perusahaan ---
        Console.WriteLine("\n=== PROSES PENDAFTARAN KARYAWAN ===");
        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelancer);

        // --- Tampilkan semua data ---
        perusahaan.DaftarKaryawan();

        Console.WriteLine("\n=== SOAL 1: Pemanggilan Kerja() pada Manager & Freelancer ===");
        manager.Kerja();
        freelancer.Kerja();

        Console.WriteLine("\n=== SOAL 2: Pemanggilan Memimpin() pada Manager ===");
        manager.Memimpin();

        Console.WriteLine("\n=== SOAL 3: Menampilkan Info Lengkap Manager ===");
        manager.InfoKaryawan();
        Console.WriteLine($"Akses Langsung — Tunjangan : Rp {manager.tunjangan:N0}");
        Console.WriteLine($"Total Gaji                 : Rp {manager.HitungGajiTotal():N0}");

        Console.WriteLine("\n=== SOAL 4: Pemanggilan Belajar() pada Magang ===");
        magang.Belajar();

        Console.WriteLine("\n=== SOAL 5: Penerapan Polymorphism — Variabel Karyawan menyimpan objek Staff ===");
        Karyawan karyawanPolymorphism = new Staff("Putra Satria", 8000000, 1000000);

        Console.WriteLine("\n=== DEMONSTRASI POLYMORPHISM (seluruh karyawan) ===");
        List<Karyawan> semuaKaryawan = new List<Karyawan> { manager, staff, magang, freelancer };
        foreach (var k in semuaKaryawan)
        {
            k.Kerja();
        }

        Console.WriteLine("\n=== SOAL 6: KESIMPULAN ===");
        Console.WriteLine(
            "1. INHERITANCE memungkinkan subclass mewarisi atribut dan perilaku\n" +
            "   dari superclass sehingga kode tidak perlu ditulis berulang.\n\n" +
            "2. METHOD OVERRIDING memberikan kemampuan bagi subclass untuk\n" +
            "   mendefinisikan ulang method warisan sesuai kebutuhan spesifiknya.\n\n" +
            "3. POLYMORPHISM memungkinkan variabel bertipe superclass menyimpan\n" +
            "   objek dari subclass manapun, dan method yang dijalankan menyesuaikan\n" +
            "   tipe objek yang sebenarnya pada saat runtime (dynamic dispatch).\n\n" +
            "4. ENCAPSULATION memastikan data internal suatu objek terlindungi\n" +
            "   dan hanya dapat diakses melalui mekanisme yang sudah ditentukan.\n\n" +
            "5. Kelas Perusahaan memanfaatkan List<Karyawan> untuk menampung\n" +
            "   berbagai jenis karyawan (Manager, Staff, Magang, Freelancer),\n" +
            "   yang merupakan implementasi nyata dari konsep polymorphism."
        );
    }
}
