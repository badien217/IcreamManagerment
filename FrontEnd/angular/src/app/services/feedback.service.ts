import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Feedback } from '../interfaces/feedback';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:5175/api/Feedbacks';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  constructor(private http: HttpClient) {}

  getAllFeedbacks(): Observable<Feedback[]> {
    return this.http.get<Feedback[]>(baseUrl);
  }

  createFeedback(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }
}
