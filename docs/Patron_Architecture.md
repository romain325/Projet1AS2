# **Patron de conception et Architecture**
==========================================================

## *Singleton*
Un des patrons de conceptions qui nous as été le plus utile est le Singleton. \
Dans un premier temps nous allons vous décrire ce qu'est un singleton et pourquoi nous l'avons utiliser dans cette situation. \
Le Singleton a un objectif simple, qu'importe d'où on l'appelle, on veut récuperé toujours la même instance. \
Nous l'avons utiliser pour notre Manager, celui-ci contient des classes telle que notre systeme de Navigation, de Connexion, d'Event ou encore de gestion des données. Rendre toutes ces classes statiques n'aurait pas été une bonne idée du tout mais nous voulions garder une seule instance de ces fonctions. Ainsi nous avons donc utiliser un Singleton.  \
Celui-ci retourne une Instance unique qu'importe la manière d'où on l'appelle. Nous utilisons aussi un PadLock dessus afin de faire en sorte qu'il soit thread-safe. \

## *Proxy*
En parlant de notre Manager, celui-ci implemente un autre patron de conception. \
Un Proxy est un objet par lequel on va passer pour obtenir une requete sur une autre instance qui de base est inaccessible à celui-ci. \
En effet celui-ci fonctionne comme un proxy, notre Manager ne contient aucune méthode et/ou property de type primitif. \
Il ne comporte que les différentes instance de classes que nous voulons utiliser, pour acceder à la Navigation, il faut apsser par le proxy qu'est le Manager.  
De même pour la DataBaseDataManager ou encore le ConnexionHandler et le EventHub. \
Celui-ci a donc un rôle de Proxy.

## *Facade*
Afin d'avoir un système de Gestion de Données interessant et efficace nous utilisons une facade. \
En effet notre systeme de Base de Données contient de nombreuses différentes classes usant différentes techniques. \
Ainsi nous avons une interface supérieur nommé IGestion qui va donner une logique et un ordre à tout ces enfants qui vont simplement apporté des strategies quand à la manière de résoudre un problème donnée. Dans notre cas: XML ou JSON, quel type de classe? etc....  
Ainsi grâce à notre stratégie l'entierté de notre systeme de base de données suit la meme logique sous jacente dicté par IGestion puis adapte pour chaque cas . \

## *Strategy*
Les Ressources contiennent beaucoup de types différents et nous avons donc décidé d'utiliser une strategie pour gérer cette famille par laquelle très peu de parametres changent. \
Notre classe nommé RessourceAccessable est utilisé comme tuteur pour tout ces différents enfants définissant des ressources telle que Style,Arome,TYpe, etc,etc.... \
Nous implémentons donc une stratégie à ce niveau là.  

