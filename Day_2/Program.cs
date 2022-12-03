
static void Part1() {
    var lines = File.ReadAllLines("input.txt");

    var scoreDictionaryOpponent = new Dictionary<char, int>() {
        {'A', 1}, // Rock
        {'B', 2}, // Paper
        {'C', 3} // Scissors
    };

    var scoreDictionary = new Dictionary<char, int>() {
        {'X', 1}, // Rock
        {'Y', 2}, // Paper
        {'Z', 3} // Scissors
    };


    int totalScore = 0;
    foreach (var line in lines) {
        var opponentMove = (char) line.Split(' ')[0][0];
        var elfSuggestedMove = (char) line.Split(' ')[1][0];

    
        totalScore += scoreDictionary[elfSuggestedMove];

        // DRAW
        if (scoreDictionaryOpponent[opponentMove] == scoreDictionary[elfSuggestedMove]) {
            totalScore += 3;
        }

        // I WIN
        if (opponentMove == 'A' && elfSuggestedMove == 'Y') {
            totalScore += 6;
        }
        // LOST
        if (opponentMove == 'A' && elfSuggestedMove == 'Z') {
            
        }

        // LOST
        if (opponentMove == 'B' && elfSuggestedMove == 'X') {
        }

        // I WIN
        if (opponentMove == 'B' && elfSuggestedMove == 'Z') {
            totalScore += 6;
        }
        
        // I WIN
        if (opponentMove == 'C' && elfSuggestedMove == 'X') {
            totalScore += 6;
        }
        
        // LOST
        if (opponentMove == 'C' && elfSuggestedMove == 'Y') {
            
        }

    }

    Console.WriteLine($"Total score: {totalScore}");

}


static void Part2() {

    var lines = File.ReadAllLines("input.txt");

    var scoreDictionaryOpponent = new Dictionary<char, int>() {
        {'A', 1}, // Rock
        {'B', 2}, // Paper
        {'C', 3} // Scissors
    };

    var scoreDictionary = new Dictionary<char, int>() {
        {'X', 1}, // Rock
        {'Y', 2}, // Paper
        {'Z', 3} // Scissors
    };


    int totalScore = 0;
    foreach (var line in lines) {
        var opponentMove = (char) line.Split(' ')[0][0];
        var elfSuggestedMove = (char) line.Split(' ')[1][0];


        var whatToChoose = WhatToChoose(opponentMove, elfSuggestedMove);
    
        totalScore += scoreDictionary[whatToChoose];

        // DRAW
        if (scoreDictionaryOpponent[opponentMove] == scoreDictionary[whatToChoose]) {
            totalScore += 3;
        }

        // I WIN
        if (opponentMove == 'A' && whatToChoose == 'Y') {
            totalScore += 6;
        }
        // LOST
        if (opponentMove == 'A' && whatToChoose == 'Z') {
            
        }

        // LOST
        if (opponentMove == 'B' && whatToChoose == 'X') {
        }

        // I WIN
        if (opponentMove == 'B' && whatToChoose == 'Z') {
            totalScore += 6;
        }
        
        // I WIN
        if (opponentMove == 'C' && whatToChoose == 'X') {
            totalScore += 6;
        }
        
        // LOST
        if (opponentMove == 'C' && whatToChoose == 'Y') {
            
        }
    }

    static char WhatToChoose(char opponentMove, char expectedResult)
    {
        // DRAW
        if (expectedResult == 'Y') {
            switch(opponentMove) {
                case 'A':
                    return 'X';
                case 'B':
                    return 'Y';
                case 'C':
                    return 'Z';
            }
        }

        // I need to lose
        if (expectedResult == 'X') {
            switch(opponentMove) {
                case 'A':
                    return 'Z';
                case 'B':
                    return 'X';
                case 'C':
                    return 'Y';
            }
        }

        // I need to win
        if (expectedResult == 'Z') {
            switch(opponentMove) {
                case 'A':
                    return 'Y';
                case 'B':
                    return 'Z';
                case 'C':
                    return 'X';
            }
        }
        return '-';
    }
    Console.WriteLine($"Total score: {totalScore}");
}


Part1();
Part2();