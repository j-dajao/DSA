#include <stdio.h>
#include "functions.c"

int main(){
    Stack S;
    initList(&S);

    nameType n2 = {"Luke", "Cabahug", 'E'};

    studType s1 = createStudent((nameType){"Clarence","Diangco",'C'},101,"BSIT");
    studType s2 = {n2, 102, "BSIT"};
    studType s3 = {{"Alice", "Brown", 'C'}, 103, "BSCE"};

    printf("Pushing students...\n");
    push(&S, s1);
    push(&S, s2);
    push(&S, s3);

    printf("\nDisplaying stack (display1: Top → Bottom):\n");
    display1(S);

    printf("\nTop element:\n");
    top(S);

    printf("\nPop one element...\n");
    pop(&S);
    printf("After pop (display2: Bottom → Top):\n");
    display2(S);

    printf("\nPop and return:\n");
    studType popped = popReturn(&S);
    printf("Popped -> %s %c %s, id: %d, course: %s\n",
           popped.studName.FName,
           popped.studName.MI,
           popped.studName.LName,
           popped.id,
           popped.course);

    printf("\nFinal stack (display3: Bottom → Top):\n");
    display3(S);

    printf("\nClearing stack...\n");
    makeNull(&S);
    printf("After clear:\n");
    display4(S);

    return 0;
}
