# Assures-toi d'avoir le client ef core.

1. Avoir installé le client ef core https://learn.microsoft.com/en-us/ef/core/get-started/overview/install#get-the-net-cli-tools
1. Posser une instance de mariadb sur ta machine avec l'utilisateur root:root
1. MariaDB possède une table nommée PWATodos (IA niveau 3)
1. Faire un build de la solution.
1. Ouvrir une fenêtre console dans visual studio en cliquant droit sur le projet CleanTodo.Infrastructure + terminal
1. Faire la commmande ci-dessous

```
dotnet ef database update --startup-project ..\CleanTodo.WebAPI --project ./
```

Ce que ça fait? Ça applique les migrations dans le dossier migrations.

**Q:** : Va voir le fichier InitialCreate. Qu'est-ce qu'il fait, que fait Up? Que fait Down?
**R** :

Si tu vas voir dans mariadb, tu vas remarquer que deux tables sont crées à partir de notre modèle.

# Le fonctionnement de l'application. 

1. Individuellement, crée un diagramme de séquence (papier ou sur sur lucid chart) qui représente le chemin parcouru par un appel lorsqu'on appel la route GetAll d'un Todo.
2. Une fois que c'est fait, compare ton travail à un collègue.

# Pour revenir sur l'architecture

Afin de bien comprendre le fonctionnement de l'architecture, bases-toi sur le fonctionnement du FindById et crée la route pour ajouter, modifier et ajouter un todo.

Une fois que c'est fait, tu peux recharger le projet tests et valider si ton application fonctionne adéquatement.

Voici ce que tu auras à faire pour l'ajout.

1. Ajouter le DTO `CreateTodoDto` avec la propriété nécessaires pour créer un todoo
2. Ajouter une méthode dans l'interface du Repository qui permet d'ajouter un todo de type Todo.
3. Implémenter cette nouvelle méthode dans le repo de la couche infrastructure. Utilise _context.Todos pour trouver comment ajouter (addjouter) un nouvel élément de façon asynchrone. N'oublie pas de retourner le todo créé.

Attention, le retour sera une entitée. Si tu veux retourner la valeur, tu dois faire `return createdTodo.Entity`. De plus, avec EfCore, on doit sauvegarder les changements avec la ligne ` _context.SaveChangesAsync();`

4. Ajouter un useCase dans le dossier Todo de la couche Application.
5. Valide que le contenu du todo fait au moins trois caractères. Si jamais il n'est pas valide, retourne une nouvelle exception qui se nomme InvalidFormatException. Si le todo est valide, sauvegarde le avec le repo et retoune ce dernier.

Attention, le useCase reçoit un CreateTodoDTO en paramètre et retourne un TodoDto. De plus, le repo reçoit un Todo en paramètre. C'est donc au useCase de transformer le Todo en ses différentes formes.

Voici la signature de la méthode pour t'aider : `public async Task<TodoDto> Execute(CreateTodoDto createTodoDto)`

6. Ajoute le useCase dans le dossier DependencyInjection du projet Application. Ça permet de passer le UseCase dans le constructeur et d'y injecter le repo automatiquement.
7. Ajoute le useCase dans le controlleur et test le tout via le swagger.


Le premier ajout devrait te prendre une heure tout au plus. Les suivants seront plus rapides et simple à faire.