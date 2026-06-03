# 🏨 Otel Rezervasyon Otomasyonu

<div align="center">

<img src="https://readme-typing-svg.demolab.com?font=Fira+Code&size=22&pause=1000&color=1D9E75&center=true&vCenter=true&width=600&lines=Otel+Rezervasyon+Otomasyonu;Entity+Framework+%2B+C%23+%2B+MSSQL;YBS2+Ders+Projesi" alt="Typing SVG" />

<br/><br/>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-6.5.2-0078D4?style=for-the-badge&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio_2022-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Windows](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)

<br/>

![GitHub repo size](https://img.shields.io/github/repo-size/bakirtugce96-ops/OtelRezervasyon?color=1D9E75&label=Proje%20Boyutu)
![GitHub last commit](https://img.shields.io/github/last-commit/bakirtugce96-ops/OtelRezervasyon?color=512BD4&label=Son%20G%C3%BCncelleme)
![GitHub stars](https://img.shields.io/github/stars/bakirtugce96-ops/OtelRezervasyon?color=FFD700&label=Y%C4%B1ld%C4%B1z)

</div>

---

## 📖 Proje Hakkında

> **YBS2** dersi kapsamında **C# Windows Forms** ve **Entity Framework 6** ile geliştirilmiş tam fonksiyonlu **Otel Rezervasyon Yönetim Sistemi**.

Sistem; misafir kayıtları, oda yönetimi, rezervasyon takibi ve gelir istatistikleri gibi temel otel operasyonlarını dijital ortama taşımak için tasarlanmıştır.

---

## ✨ Modüller

<table>
<tr>
<td width="50%">

### 🏠 Ana Menü
- Modern koyu tema arayüzü
- 4 ana modüle tek tıkla erişim
- Misafirler · Odalar · Rezervasyonlar · Raporlar

</td>
<td width="50%">

### 👤 Misafir Yönetimi
- ➕ Yeni misafir ekleme
- ✏️ Bilgi güncelleme
- 🗑️ Kayıt silme
- 📋 Tüm misafirleri listeleme

</td>
</tr>
<tr>
<td width="50%">

### 🚪 Oda Yönetimi
- ➕ Oda ekleme (kapasite sınırlı)
- 🗑️ Oda silme
- 📋 Listeleme + oda sayısı takibi
- 🏷️ Standart / Deluxe / Suite

</td>
<td width="50%">

### 📅 Rezervasyon Yönetimi
- ➕ Rezervasyon oluşturma
- ⚠️ Tarih çakışma kontrolü
- 🗑️ İptal etme
- 📋 Tüm rezervasyonları listeleme

</td>
</tr>
</table>

---

## 🏨 Oda Kapasitesi

```
┌─────────────────────────────────────────────────┐
│              OTEL KAPASİTESİ (50 ODA)           │
├──────────────┬──────────┬───────────────────────┤
│  Oda Tipi    │ Kapasite │ Doluluk Takibi         │
├──────────────┼──────────┼───────────────────────┤
│ 🛏️ Standart  │  25 oda  │ Gerçek zamanlı sayaç  │
│ ⭐ Deluxe    │  15 oda  │ Gerçek zamanlı sayaç  │
│ 👑 Suite     │  10 oda  │ Gerçek zamanlı sayaç  │
├──────────────┼──────────┼───────────────────────┤
│   TOPLAM     │  50 oda  │                       │
└──────────────┴──────────┴───────────────────────┘
```

---

## 📊 LINQ Raporları

```csharp
// 🥇 En çok rezervasyon yapan misafir
db.Table_Reservation
  .GroupBy(r => new { r.Guest.Guest_Name, r.Guest.Guest_Surname })
  .Select(g => new { Ad = g.Key, Toplam = g.Count() })
  .OrderByDescending(x => x.Toplam)
  .FirstOrDefault();

// 💰 En yüksek gelirli oda tipi
db.Table_Reservation
  .Include(r => r.Room.RoomType)
  .GroupBy(r => r.Room.RoomType.RoomType_Name)
  .Select(g => new { Tip = g.Key, Gelir = g.Sum(r => r.Room.Room_Price) })
  .OrderByDescending(x => x.Gelir)
  .FirstOrDefault();
```

---

## 🗄️ Veritabanı Şeması

```
                    ┌──────────────────┐
                    │  Table_RoomType  │
                    ├──────────────────┤
                    │ 🔑 RoomType_Id   │
                    │    RoomType_Name │
                    └────────┬─────────┘
                             │ 1
                             │
                             │ N
              ┌──────────────▼──────────────┐
              │         Table_Room          │
              ├─────────────────────────────┤
              │ 🔑 Room_Id                  │
              │    Room_Number              │
              │    Room_Price               │
              │ 🔗 RoomType_Id (FK)         │
              └──────────────┬──────────────┘
                             │ 1
                             │
                             │ N
┌──────────────┐   ┌─────────▼──────────────┐
│ Table_Guest  │   │   Table_Reservation    │
├──────────────┤   ├────────────────────────┤
│🔑 Guest_Id   │ 1 │ 🔑 Reservation_Id      │
│  Guest_Name  ├───┤ 🔗 Guest_Id (FK)       │
│  Surname     │ N │ 🔗 Room_Id (FK)        │
│  Phone       │   │    CheckIn_Date        │
│  Email       │   │    CheckOut_Date       │
└──────────────┘   └────────────────────────┘
```

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Versiyon | Amaç |
|:---:|:---:|:---|
| ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white) | .NET 4.7.2 | Ana programlama dili |
| ![EF](https://img.shields.io/badge/Entity_Framework-512BD4?style=flat-square&logo=dotnet&logoColor=white) | 6.5.2 | ORM / Veritabanı işlemleri |
| ![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white) | Express | Veritabanı |
| ![WinForms](https://img.shields.io/badge/WinForms-0078D4?style=flat-square&logo=windows&logoColor=white) | - | Kullanıcı arayüzü |
| ![LINQ](https://img.shields.io/badge/LINQ-1D9E75?style=flat-square) | - | Veri sorgulama |
| ![Git](https://img.shields.io/badge/Git-F05032?style=flat-square&logo=git&logoColor=white) | 2.54.0 | Versiyon kontrolü |

---

## ⚙️ Kurulum

```bash
# 1. Repoyu klonla
git clone https://github.com/bakirtugce96-ops/OtelRezervasyon.git

# 2. Visual Studio ile aç
otelRezervasyon1.sln

# 3. App.config'i düzenle (server adını değiştir)
Data Source=SENIN_SERVER_ADIN;Initial Catalog=OtelRezervasyon

# 4. Çalıştır
F5
```

---

## 📐 UML Diyagramları

| Sınıf | Açıklama |
|:---:|:---|
| `Table_Guest` | Misafir modeli — ICollection<Reservation> ile one-to-many |
| `Table_Room` | Oda modeli — virtual RoomType navigation property |
| `Table_RoomType` | Oda tipi — ICollection<Room> ile one-to-many |
| `Table_Reservation` | Aracı tablo — Guest ve Room'a many-to-one |
| `otelRezervasyon1Context` | DbContext — 4 DbSet tanımı |

> UML görseli için `YouML_image.png` dosyasına bakınız.

---

<div align="center">

### 👤 Geliştirici

[![GitHub](https://img.shields.io/badge/bakirtugce96--ops-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/bakirtugce96-ops)

---

*YBS2 Dersi — Otel Rezervasyon Otomasyonu*

⭐ **Beğendiyseniz yıldız vermeyi unutmayın!**

</div>
