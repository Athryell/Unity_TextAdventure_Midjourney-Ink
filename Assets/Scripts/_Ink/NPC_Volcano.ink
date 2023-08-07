VAR firstTime = true


{firstTime:
    Ah, quanto tempo!
    So che non hai tempo da perdere quindi sarò diretto
    forse lo saprai già ma per uscire devi passare attraverso le rovine del castello
    per accedervi hai bisogno di una chiave che posso forgiarti, dovrei ricordare ancora come forgiartela...
    ovviamente devi portarmi la materia prima, minerali che si trovano sul fondo del lago
    visto che sicuramente non vedrai un tubo posso darti questa utile maschera, al momento però è rovente quindi ti faccio un favore a dirti che prima dovrai raffreddarla
    Abbiamo dell'acqua rimanente a portata di mano?
        * [Sì, per fortuna non l'ho bevuta tutta...] -> waterTrue
        * [Ehm... no, avevo sete e l'ho finita.] -> waterFalse
        
    - else:
    
    Hai portato l'acqua?
        * [*Annuisco*] -> waterTrue
        * [Ah, ecco cosa dovevo fare!] -> waterFalse
}

=== waterTrue ===
Allora bevine un sorso ma trattienilo in bocca,
vediamo se funziona...
Bevi e trattieni l'acqua in bocca #action
    * ["Mmmghg mmghghh m!"] -> spitWater

=== waterFalse ===
Stiamo qui a piangerci addosso?
Vai a prenderne un po',
se non hai voglia di alzarti dalla sedia puoi trovarne sicuramente un po' al lago.
Dove vuoi prendere l'acqua? #action
    * [Uff, e va bene, mi alzo e vado a prenderne un po']
        Vai a prenderla, ti aspettiamo qui.
        **[Ok, ho un bicchiere qui di fianco a me] -> waterTrue
    * [Ho trovato una posizione troppo comoda sulla sedia, andiamo al lago] -> END

=== spitWater ===
#spit
Un po' drammatico ma è stato sufficiente a trasferirla da questo lato
Tieni, ora che hai raffreddato la maschera puoi prenderla
Ora puoi deglutire #action
    * [Grazie]
    
- Bene, in fondo al lago puoi trovare i materiali necessari
mettili qui dentro e torna quando me li avrai portati
    * [A tra poco]

-> END