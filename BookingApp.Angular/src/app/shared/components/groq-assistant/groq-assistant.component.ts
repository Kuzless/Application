import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { GroqRequestInterface } from '../../../booking/interfaces/booking-personal-page/groq-request.interface';
import { ApiService } from '../../services/api.service';
import { AsyncPipe, CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FormatImgPipe } from '../../../booking/pipes/format-img.pipe';

@Component({
  selector: 'app-groq-assistant',
  imports: [AsyncPipe, ReactiveFormsModule, CommonModule, FormatImgPipe],
  templateUrl: './groq-assistant.component.html',
  styleUrl: './groq-assistant.component.css',
})
export class GroqAssistantComponent {
  @Input() groqEndpoint: string = 'Groq';
  @Input() templateMessages: string[] = [];

  private readonly userId: string = localStorage.getItem('uniqueId')!;
  readonly iconsUrl: string = '';
  readonly iconsFormat: string = '.svg';
  readonly sendIconName: string = 'send';
  groqForm: FormGroup;
  groqResponse$?: Observable<string>;

  activeQuestion: string = '';

  get message(): string {
    return this.groqForm.get('message')?.value;
  }

  constructor(private apiService: ApiService, private fb: FormBuilder) {
    this.groqForm = fb.group({
      message: ['', [Validators.required]],
    });
  }

  onSubmit() {
    this.sendRequest(this.message);
  }

  submitTemplate(message: string) {
    this.sendRequest(message);
  }

  private sendRequest(prompt: string) {
    let request: GroqRequestInterface = {
      userId: this.userId,
      prompt: prompt,
    };
    this.groqResponse$ = this.apiService.post<GroqRequestInterface>(
      this.groqEndpoint,
      request
    );
    this.activeQuestion = prompt;
  }
}
