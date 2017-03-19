# Nulta zadaća

---

## JMBAG
0036484664

---

## Pitanja

### Pitanje 1
Dodao se ClassLibrary.dll u bin/Debug.
Kad se makne taj .dll i pokrene aplikaciju aplikacija se ruši zbog iznimke System.IO.FileNotFoundException jer očekuje referencu izbačeni .dll čiju metodu koristi. 
Da bi se poslala aplikacija dovoljno je poslati .exe i sve .dll-ove koji se koriste.

### Pitanje 2
Aplikacija je koristila staru verziju jer nije buildala novu verziju ClassLibrary-a među svoje reference .dll-ove.

### Pitanje 3
"Pero: Hello World"

### Pitanje 4
Dodao se PeroClassLibrary.dll u bin/Debug.

### Pitanje 5
Aplikacija i build i dalje rade jer se pri dodavanju vanjskog .dll-a u References on cijeli kopirao u taj projekt.

### Pitanje 6
Build proces se uspješno izvršio, a obrisani direktorij ponovno pojavio.
