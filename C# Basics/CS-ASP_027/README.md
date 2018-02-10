# Hero vs. Monster (Loops)
This application runs a very simple text based calculation for a "battle" between a hero character and a monster character. The battle logic is written two different ways as I learned the difference between a while loop and a do-while loop. The do-while loop allowed my code to run once no matter what, and the while loop would only run my code if the conditional statement evaluated to true.

### Code Snippet:
    Random random = new Random();

    int heroHealth = 30;
    int monsterHealth = 30;

    string result = "";

    // Hero gets bonus first attack 
    monsterHealth -= random.Next(1, 20);

    int round = 0;
    result += "<br />Round: " + round;
    result += String.Format("<br />Hero attacks first, leaving monster with {0} health.", 
        monsterHealth);


    // While battle logic, does not run the code if never true
    
    while (heroHealth > 0 && monsterHealth > 0)
    {
        int heroDamage = random.Next(1, 10);
        int monsterDamage = random.Next(1, 11);

        monsterHealth -= heroDamage;
        heroHealth -= monsterDamage;

        result += "<br />Round: " + ++round; //increment round number, then execute code
        result += String.Format("<br />Hero causes {0} damange, leaving monster with {1} health.", heroDamage, monsterHealth);
        result += String.Format("<br />Monster causes {0} damange, leaving hero with {1} health.<br />", monsterDamage, heroHealth);
    }
    

    // Do While battle logic, runs block at least once, currently disabled
    /*
    do
    {
        int heroDamage = random.Next(1, 10);
        int monsterDamage = random.Next(1, 11);

        monsterHealth -= heroDamage;
        heroHealth -= monsterDamage;

        result += "<br />Round: " + ++round; //increment round number, then execute code
        result += String.Format("<br />Hero causes {0} damange, leaving monster with {1} health.", heroDamage, monsterHealth);
        result += String.Format("<br />Monster causes {0} damange, leaving hero with {1} health.<br />", monsterDamage, heroHealth);
    } while (heroHealth > 0 && monsterHealth > 0);
    */


    if (heroHealth > 0)
    {
        result += "<br />Hero wins!";
    }
    else
    {
        result += "<br /> Monster wins!";
    }


    resultLabel.Text = result;