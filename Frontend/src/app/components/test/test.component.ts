import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Question } from 'src/app/question.model';
import { ServiceService } from 'src/app/service/service.service';

@Component({
  selector: 'quiz-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
})
export class TestComponent implements OnInit {
  
  question: any = {};
  points: number = 0;
  name: string = '';
  questionList: Array<Question> = [];
  currentQuestion: number = 0;
  correctAnswer: number = 0;
  incorrectAnswer: number = 0;
  isQuizCompleted: boolean = false;

  constructor(
    private questionService: ServiceService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.name = localStorage.getItem('name')!;
    this.getAllQuestions();
    this.questionList = this.route.snapshot.data['message'];
  }
  // Method for getting data
  getAllQuestions() {
    this.questionService.getQuestions().subscribe((res) => {
      this.questionList = res;
      console.log(this.questionList);
    });
  }

  // Method for next question
  nextQuestion() {
    this.question = this.questionList[this.currentQuestion];
    this.currentQuestion += 1;
    console.log(this.questionList.length);
    console.log(this.points);
  }

  // Method for previous question
  prevQuestion() {
    this.currentQuestion -= 1;
    this.question = this.questionList[this.currentQuestion];
  }

  // Method for reseting the quiz
  resetQuiz() {
    this.getAllQuestions();
    this.currentQuestion = 0;
  }

  // select method
  selectedAnswer: any = {};
  select(event: any, id: number) {
    console.log(event.target.value);
    let ans = event.target.value;
    let data = {
      id: id,
      userAnswer: ans,
    };
    this.selectedAnswer = data.userAnswer;
    this.check(id);
  }

  // Check method for validating
  check(id: number) {
    this.questionService.getAnswer(id).subscribe((res) => {
      if (this.selectedAnswer == res?.correctAnswer) {
        this.points += 10;
        console.log('you selected correct answer');
      } else {
        console.log(
          `you selected wrong answer, u selected ${this.selectedAnswer}, the crt is : ${res?.correctAnswer}`
        );
      }
      if (this.currentQuestion + 1 == this.questionList.length) {
        this.isQuizCompleted = true;
      }
    });
  }
}
