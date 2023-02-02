import { Component } from '@angular/core';

@Component({
  selector: 'quiz-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss'],
})
export class WelcomeComponent {
  name: string = '';

  startQuiz() {
    localStorage.setItem('name', this.name);
  }
}
