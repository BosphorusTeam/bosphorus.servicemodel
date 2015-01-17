Bosphorus WCF Servisleri için aktivasyon altyapısı

Bu paketi kullanmak için WCF Service Application tipinde bir projeye eklemeniz gereklidir. Eğer farklı tipte bir proje yarattıysanız şimdi değiştirin.
Bu paket sayesinde servislerinizi IIS / WAS üzerinde host etme olanağına kavuşacaksınız. Öncelikle debug edebilmek için yerel makinanızda IIS kurulumu yapılmış
olduğunu kontrol edin.

Servisinizi IIS / WAS üzerinde debug edebilmek için aşağıdaki adımları izleyin;
1. WCF Service Application projesine servis sınıfınızı içeren projeye referans ekleyin
2. WCF Service Application projesine ait özelliklerde "Web" sekmesinde "Servers" başlığından "Local IIS" seçin
3. Uygun bir url oluşturduktan sonra "Create Virtual Directory" butonuna basın