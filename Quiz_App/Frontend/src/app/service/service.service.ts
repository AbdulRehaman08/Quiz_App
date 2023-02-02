import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from '../question.model';

@Injectable({
  providedIn: 'root',
})
export class ServiceService {
  constructor(private http: HttpClient) {}

  getApi = 'https://localhost:7217/api/Quizz';
  deleteApi = 'https://localhost:7217/api/Quizz/';
  editApi = 'https://localhost:7217/api/Quizz?id=';
  getPageApi = 'https://localhost:7217/api/Quizz/page?PageNumber=';
  searchApi = 'https://localhost:7217/api/Quizz/search?name=';
  getAnswerApi = 'https://localhost:7217/api/Quizz/answer?id=';
  sortApi = 'https://localhost:7217/api/Quizz/sorting';
  
  // Get method
  getQuestions(): Observable<Array<Question>> {
    return this.http.get<Array<Question>>(this.getApi);
  }

  // Post method
  postQuestion(question: Question): Observable<any> {
    return this.http.post(this.getApi, question);
  }

  // Edit method
  editQuestion(question: Question): Observable<any> {
    return this.http.put<Array<Question>>(
      this.editApi + `${question.id}`,
      question
    );
  }

  // Delete method
  deleteQuestion(id: number): Observable<any> {
    return this.http.delete<number>(this.deleteApi + id);
  }

  // pagging method
  getPaging(pageNo: any, pageSize: any): Observable<any> {
    return this.http.get(this.getPageApi + `${pageNo}&PageSize=${pageSize}`);
  }

  // searching method
  searched(name: string): Observable<Array<Question>> {
    return this.http.get<Array<Question>>(this.searchApi + name);
  }

  //getAnswerById method
  getAnswer(id: number): Observable<Question> {
    return this.http.get<Question>(this.getAnswerApi + id);
  }

  //sorting method
  sorting(): Observable<Array<Question>> {
    return this.http.get<Array<Question>>(this.sortApi);
  }
}
