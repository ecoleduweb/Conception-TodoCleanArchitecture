# Pour instancier la bd, exécuter dans

1. Installer ef core https://learn.microsoft.com/en-us/ef/core/get-started/overview/install 
2. Faire un build de la solution.
3. Ouvrir une fenêtre console dans visual studio en cliquant droit sur le projet CleanTodo.Infrastructure + terminal
4. Faire la commmande ci-dessous

```
dotnet ef database update --startup-project ..\CleanTodo.WebAPI --project ./
```

# Pour comprendre le fonctionnement

1. Individuellement, crée un diagramme de séquence sur lucid chart qui représente le chemin parcouru par un appel lorsqu'on ajoute un TODO.
2. Une fois que c'est fait, compare ton travail à un collègue.

# Pour comprendre l'architecture

1. Individuellement, va lire cet article : https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
2. Une fois que c'est fait, dans tes propres mots, décrit ce que fait : 

- La couche application
- La couche domaine
- La couche infrastrucutre
- La couche WebAPI

Tu peux t'aider de l'IA pour valider ta compréhension. Pose des questions du style :"J'ai dit que la couche application dans la clean architecture permettait de faire ça pis ça. Est-ce que c'est vrai?"

# Pour valider ta compréhension

1. En équipe de deux, ajoute le nécessaire pour valider si un utilisateur qui appelle la route /login peut se connecter en validant son nom d'utilisateur ("root") et son mot de passe ("root") **UNIQUEMENT** dans le controleur.

**Q:** : Disons qu'on met le mot de passe dans un fichier de configuration, quels sont les problèmes ici?
**R** :

2. Ajoute le nécessaire pour que l'utilistateur soit dans la base de données en suivant les étapes ci-dessous. 

Ajoute l'entité utilisateur

**Q** : De quels champs aura-t-il besoin?

**R** :

**Q** : Est-ce que l'autocomplete de l'IA a toujours raison?

**R** : 

Ajoute une migration pour que la table users soit créée avec la commande suivante :
`dotnet ef migrations add XXXXXXXXXXXXX_LE_NOM_DE_TA_MIGRATION_XXXXXXXXXXXXXXXX --startup-project ..\CleanTodo.WebAPI --project ./`

Dans le fichier de migration qui a été créé, ajoute un utilisateur dans la base de données en te basant sur le code ci-dessous.

```C#
migrationBuilder.InsertData(
    table: "Todos",
    columns: new[] { "Id", "Text", "IsCompleted", "Date" },
    values: new object[] { Guid.NewGuid(), "Learn Clean Architecture", false, DateTime.UtcNow }
);
```

**Q** : Dans quelle méthode ira l'utilisateur? Up ou Down?

**R** : 
 

Tu dois en ensuite appliquer la migration à ta BD avec la commande `dotnet ef migrations update --startup-project ..\CleanTodo.WebAPI --project ./` que tu as déjà fait plus haut.

1. Ajoute le modèle du domaine de ton user en te basant sur les todos.
2. Crée un useCase de Login. La logique du login sera dans ce use case.
3. On valide quoi dans le nom et le mot de passe? Crée un validator.
4. Ajoute un test pour ton useCase.
5. Test ton login avec le swagger.

Good! Le login fonctionne!

# Faire fonctionner le login, mais mieux

1. Est-ce que ton application est sécuritaire? Est-elle protégée? Non? Complète le login pour créer un token jwt.

**Q** : C'est quoi un token JWT? Ça sert à quoi? C'est quoi un access_token?

**R** : 

2. Suite à un login fonctionnel, retourne un token dans les cookies.

# Valider qu'on est connecté

1. Ajoute du code dans ton application qui permet de valider si l'utilisateur crée, modifie ou supprime un todo lorsqu'il est connecté. Tu dois valider que l'accessToken dans le cookie est valide. Pas besoin de valider qu'il existe dans la BD.
2. Avec l'IA, demande comment tu pourrais produire un middleware pour centraliser la logique de ton code.

# Dernière chose
Est-ce que ton utilisateur a un mot de passe encrypté dans la base de données? Si la réponse est non, ajoute une route `/register` qui permet de créer un compte et qui sauvegarde le mot de passe encrypté.

# Dernière dernière chose.

**Q** : Dans tes mots, comment fonctionne l'authentification sur un site web?

**R** :

**Q** : Va voir sur internet comment on s'authentifie avec une application en .net core. Est-ce que tout ce que tu as fait est représentatif de l'industrie?

**R** : 
