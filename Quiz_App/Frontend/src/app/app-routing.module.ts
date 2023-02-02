import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { QuizResolver } from './resolver/quiz.resolver';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { AboutComponent } from './components/about/about.component';
import { TestComponent } from './components/test/test.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'welcome',
    pathMatch: 'full',
  },
  {
    path: 'welcome',
    component: WelcomeComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    resolve: { message: QuizResolver },
  },
  {
    path: 'about',
    component: AboutComponent,
  },
  {
    path: 'test',
    component: TestComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
