# Projekt-dotnet
1. Uruchamianie aplikacji

Program można uruchamiać poprzez plik RzeczyDoOddaniaV2.sln lub plik RzeczyDoOddaniaV2.csproj w Folderze RzeczyDoOddaniaV2 (najlepiej w Visual Studio 22, ponieważ na nim robiłem testy i nie wiem czy starsze wersje Visuala nie spowodują problemów)

Po uruchomieniu aplikacji należy w Packet Manager Console wpisać:
Update-Database -Context DataContext, a następnie
Update-Database -Context ApplicationDbContext

Następnie należy włączyć PowerShella:
![obraz](https://user-images.githubusercontent.com/101111673/174493089-2413affe-5375-412d-b393-cbcac9bd2438.png) i PowerShell może się odpalić w dwóch różnych katalogach

Jeżeli PowerShell otworzy się w tej lokacji:
![obraz](https://user-images.githubusercontent.com/101111673/174493123-92a82888-cd74-4c75-add3-d8446e515e74.png)

wtedy należy wpisać komendę cd .\RzeczyDoOddaniaV2\
![obraz](https://user-images.githubusercontent.com/101111673/174493172-3eeb2332-7db9-4cc7-b21b-a6705860a5b6.png)

A druga możliwość gdy PowerShell otworzy się w takiej lokacji:
![obraz](https://user-images.githubusercontent.com/101111673/174493204-fb3174b0-2e19-4d89-9bfd-793a3695e618.png)
wtedy nic nie musimy robić

Następnym krokiem jest wpisanie komendy: dotnet user-secrets set SendGridKey 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
Powinien wyskoczyć taki komunikat:
![obraz](https://user-images.githubusercontent.com/101111673/174493270-5826bf66-e1e2-46ea-a393-0ecdc8f39ad1.png)

Jeżeli jednak wyskoczy jakiś błąd to możliwe, że trzeba będzie wpisać komendę dotnet user-secrets init i spróbować jeszcze raz

Po powyższych krokach program powinien być już gotowy do działania.





