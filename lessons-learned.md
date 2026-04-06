1. De ce folosim Repository Pattern?

   Folosim Repository Pattern pentru ca ne ajuta sa separam baza de date de restul aplicatiei. Practic daca am schimba baza de date pentru un proiect va trebui sa modificam doar Repository-ul si nu toata aplicatia.

2. Ce s-ar intampla daca apelam _context direct din Controller?

   Daca am folosi _context direct in Controller, acesta ar fi strans legat de o tehnologie specifica - EF Core.

3. De ce avem un Service Layer separat?

   Service Layer este locul unde se afla logica de business. Controller-ul doar primeste cererea, in timp ce Service-ul decide ce se intampla cu aceasta.

4. Ce logica ar ajunge in controller fara el?
  
   Ar putea ajunge calcule mai complexe, validari sau procesare de imagini. Pe scurt, lucruri care ar depinde de inteligenta aplicatiei.
   
5. De ce folosim interfete (IArticleRepository, IArticleService)?

   Intefetele ne permit sa lucram cu contracte si nu cu implementari fixe.

6. Dati un exemplu din cod.

   In ArticlesController, noi injectam IArticleService. Controller-ul foloseste metoda AddAsync, dar nu il intereseaza cum salaveaza serviciul datele (de exemplu pe disc sau intr-o baza de date).

7. Cum ajuta aceasta structura la adaugarea unui API REST sau a unei aplicatii mobile?

   API REST: Am putea crea un nou controller care sa returneze fisiere JSON in loc de View-uri HTML. Iar controller-ul nou va injecta aceleasi Servicii pe care le-am folosit deja la aplicatia Web.
   Aplicatie Mobila: Mobilul poate apela API-ul creat asa cum am spus mai sus si nu ar mai trebui sa scriem logica pentru salvarea articolelor sau validarea lor, pentru ca exista deja in Serice Layer.

   
