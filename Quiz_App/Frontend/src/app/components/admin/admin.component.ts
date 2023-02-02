import { Question } from '../../question.model';

import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../service/service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'quiz-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  constructor(
    private service: ServiceService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  page: any = 1;
  size: any = 25;
  name: string = '';
  psize: any = ['Select', 1, 3, 5, 10, 15, 20];
  QuestionArray: Array<Question> = [];

  question = new Question();

  ngOnInit(): void {
    this.QuestionArray = this.route.snapshot.data['message'];
  }

  // Get method
  getAllQuestions() {
    this.service.getQuestions().subscribe((res) => {
      this.QuestionArray = res;
    });
  }

  // clearing the object for Adding Questions
  clearData() {
    this.question = new Question();
  }

  // Post method
  postQuestions(question: Question) {
    this.service.postQuestion(question).subscribe((res) => {
      this.QuestionArray.push(res);
      this.getAllQuestions();
    });
  }

  //Edit method
  editQuestions(question: Question) {
    this.service.editQuestion(question).subscribe((res) => {
      this.getAllQuestions();
    });
  }

  // Delete method
  deleteQuestion(id: number) {
    if (confirm('Do you want to delete?') == true) {
      this.service.deleteQuestion(id).subscribe((res) => {
        this.getAllQuestions();
      });
    }
  }

  // methode for Updating the content
  edit(question: any) {
    console.log(question);
    this.question.questionName = question.questionName;
    this.question.answer_1 = question.answer_1;
    this.question.answer_2 = question.answer_2;
    this.question.answer_3 = question.answer_3;
    this.question.answer_4 = question.answer_4;
    this.question.correctAnswer = question.correctAnswer;
    this.question.id = question.id;
  }

  // Pagging methods
  onPageChange(event: any) {
    this.page = event;
    this.getAllQuestions();
  }
  onPageSizeChange(event: any) {
    this.size = event.target.value;
    this.page = 1;
    this.getAllQuestions();
  }

  getByPage(pageNo: any, pageSize: any) {
    this.service.getPaging(pageNo, pageSize).subscribe((res) => {});
  }

  // search method
  search(name: string) {
    console.log(this.name);
    if (name == '') {
      this.reDirectTo();
      console.log('redirect');
    }
    this.service.searched(name).subscribe((res) => {
      this.QuestionArray = res;
      console.log(res);
    });
  }

  reDirectTo() {
    window.location.reload();
  }

  sort() {
    this.service.sorting().subscribe((res) => {
      this.QuestionArray = res;
    });
  }
}
