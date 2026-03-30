# Uczelniana Wypożyczalnia Sprzętu - APBD1

## Jak uruchomić aplikację?
1. Otworzyć terminal w głównym folderze projektu.
2. Odpalić komendę: `dotnet run`
3. Program przejdzie przez przygotowany scenariusz demonstracyjny.

---

## Uzasadnienie decyzji projektowych i architektura

Zgodnie z wymaganiami, żeby nie wrzucać całej logiki biznesowej do jednego pliku `Program.cs`,  projekt został podzielony na konkretne foldery, z których każda odpowiada za coś innego:
* **Domain:** zawiera same modele danych. To dane, bez logiki operacyjnej.
* **Repositories:** klasy do trzymania list obiektów w pamięci
* **Services:** tu znajduje się logika, która np. sprawdza, czy ktoś może wypożyczyć sprzęt.
* **Menu:** kod zajmujący się wyświetlaniem tekstu w konsoli.


### 1. Kohezja i jedna odpowiedzialność
 Użyto podejścia, żeby każda klasa robiła jedną, konkretną rzecz. Dobrym przykładem jest wyliczanie kar za spóźnienia. Wyrzucono to do zupełnie osobnej, małej klasy `PenaltyCalculator`. Dzięki temu główny serwis od wypożyczeń (`RentalService`) nie jest zawalony. Jeśli zmienią się stawki kar za dni opóźnienia, widać dokładnie, w którym jednym pliku to poprawić.

### 2. Coupling
Przykład w klasie `Rental` w ogóle nie są zapisywane całe obiekty użytkownika czy laptopa. Zapisują się tam tylko ich numery ID. Dzięki temu wypożyczenie jest lekkie, a zmiana w modelu sprzętu nie zepsuje kodu wypożyczeń.
Poza tym, w `Program.cs` użyto wstrzykiwania zależności – klasa obsługująca menu nie tworzy list i serwisów sama z siebie, tylko dostaje gotowe elementy z zewnątrz.

### 3. Dziedziczenie vs Kompozycja
Dziedziczenia użyto w `Laptop` i `Camera` czy `Projector`, to fizycznie sprzęt, dziedziczący z bazowej klasy `Equipment` przez wspólne cechy. 
Żeby połączyć studenta ze sprzętem użyto kompozycji, tworząc niezależny obiekt `Rental`, który łączy te dwa byty.

### 4. Limity i jasna obsługa błędów
Limity wypożyczeń (2 dla studenta, 5 dla pracownika) zapisamo jako stałe od razu w konkretnych klasach `Student` i `Employee`.
Dodatkowo, jeśli ktoś spróbuje wypożyczyć niedostępny sprzęt albo przekroczy swój limit, program po prostu rzuca jasny wyjątek (`InvalidOperationException`). Widać to dobrze w zrobionym scenariuszu demonstracyjnym.