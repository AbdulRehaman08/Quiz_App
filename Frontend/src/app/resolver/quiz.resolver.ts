import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ServiceService } from '../service/service.service';

@Injectable({
  providedIn: 'root',
})
export class QuizResolver implements Resolve<any> {
  constructor(private quizService: ServiceService) {}

  resolve(): Observable<any> {
    return this.quizService.getQuestions().pipe(
      catchError(() => {
        return of('Please come again after some time..');
      })
    );
  }
}
