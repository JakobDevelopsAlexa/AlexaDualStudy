# AlexaDualStudy

Alexa – How to create a Skill with with Azure & Visual Studio - Jakob Wiemer 
 
1. Azure aufsetzen und Visual Studio installieren 
Schritt 1: Microsoft-Azure Account anlegen  
Schritt 2: Benötigtes Abonnement abschließen (HPE verfügt über alle benötigten Abonnements) 
Schritt 3: Microsoft Visual Studio 2017 Community installieren 
Schritt 4: Im Launcher von Visual Studio „modify“ anklicken und das aufgelistete Azure-Packet installieren (das kann eine Weile dauern) 
Schritt 5: Ein neues Projekt anlegen 
Schritt 6: Im Solution Explorer Rechtklick auf das Projekt -> Add New Item 
Schritt 7: Im Popup-Fenster Azure-Funktion auswählen
Schritt 8: Ein neues Fenster öffnet sich -> HTTP Trigger auswählen 
Schritt 9: Im selben Fenster auf der rechten Seite statt Function -> Anonymos auswählen 
Schritt 10: Erneuter Rechtsklick auf das Projekt -> Publish 
Schritt 11: Create anklicken 
Schritt 12: Keine weiteren Einstellungen notwendig, werden bei Abonnement automatisch ausgefüllt, Name kann geändert werden, anschließend auf publish klicken 
Schritt 13: Microsoft Azure Website besuchen und in der Liste auf der linken Seite Azure Function anklicken, nun sollte die in Visual Studio angelegte Azure-Funktion dort angezeigt werden 
Schritt 14: Angelegte Funktion anklicken und die Funktions-URL abrufen und kopieren 
 
2. Amazon Developer Skill anlegen 
Wie man einen Skill anlegt, wird auf der Amazon-Developer-Plattform deutlich, dieses Schritt sparen wir hier. Das Einzige, was hier einer Erklärung berdarf, ist der Schritt Configuration. Hier muss HTTPS ausgewählt werden. Die eben kopierte Funktions-URL muss in den Kasten Default eingefügt werden. Nun haben wir unseren Endpoint. Zwei weitere wichtige Tipps: Beim SSL-Zertifikat muss die zweite Option ausgewählt werden: 

My development endpoint is a sub-domain of a domain that has a wildcard certificate from a certificate authority 

Um den Skill zu testen, muss die Test-Funktion enabled sein. Melde dich mit deinem DeveloperAccount in der Alexa-App an, verbinde ein beliebiges Alexa-Gerät, gehe auf Skill -> Meine Skills -> Aktivieren. Nun sollte der Skill, den wir im nächsten Schritt anlegen, angezeigt werden. 
 
3. Code in Visual Studio Allgemeines
Der nachfolgende Code kann verwendet werden, um einen beliebigen Frage-Antwort-Skill zu erstellen. Diesen habe ich ebenfalls genutzt, um Alexa für den DualStudy Messestand zu programmieren. Damit der Skill funktioniert, muss er einerseits auf der Developerplattform, andererseits in Visual Studio programmiert werden. Einen Skill stelle man sich vor wie eine Kiste, in der die sogenannten Intents drin sind, welche Antworten von Alexa auslösen. Diese Antworten legen wir in Visual Studio fest, die Intents auf der Developer-Plattform. Die Kiste öffnet man mit dem Invocation-Name. Beispiel: Alexa, frage das duale Studium, wie lange das Studium dauert. Wenn man einen Intent anlegt, zum Beispiel GetStudiumDauer, muss man auch verschiedene Utterances festlegen. Dies sind verschiedene Formulierungen ein und der selben Frage oder Aufforderung. Damit Alexa den User im besten Fall immer versteht, sollten zu einem Intent mindestens 20-30 Utterances festgelegt werden. Nun verlassen wir die Developer-Plattform und witmen uns Visual Studio. 
