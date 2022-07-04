import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';

import { ErrorService } from './services/error/error.service';
import { AlertifyService } from './services/alertify/alertify.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './pages/logged-out/login/login.component';
import { RegisterComponent } from './pages/logged-out/register/register.component';
import { HeaderComponent } from './layout/header/header.component';
import { NavComponent } from './layout/nav/nav.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LoggedInComponent } from './pages/logged-in/logged-in.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoadingComponent } from './components/loading/loading.component';
import { ProfileComponent } from './pages/logged-in/profile/profile.component';
import { HomeComponent } from './pages/logged-in/home/home.component';
import { LoggedOutComponent } from './pages/logged-out/logged-out.component';
import { ForgotComponent } from './pages/logged-out/forgot/forgot.component';
import { ResetComponent } from './pages/logged-out/reset/reset.component';
import { PostsComponent } from './components/posts/posts.component';
import { PostComponent } from './components/post/post.component';
import { SearchComponent } from './components/search/search.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { ProfilepreviewComponent } from './components/profilepreview/profilepreview.component';
import { SettingsComponent } from './pages/logged-in/profile/settings/settings.component';
import { DetailsComponent } from './pages/logged-in/profile/details/details.component';
import { OverviewComponent } from './pages/logged-in/profile/overview/overview.component';
import { FriendsComponent } from './pages/logged-in/profile/friends/friends.component';
import { ThreadComponent } from './pages/logged-in/thread/thread.component';
import { RequestsComponent } from './pages/logged-in/profile/requests/requests.component';
import { CommentsComponent } from './components/comments/comments.component';
import { CommentComponent } from './components/comment/comment.component';
import { MainPostComponent } from './components/main-post/main-post.component';
import { CreateCommentComponent } from './components/create-comment/create-comment.component';
import { RecommendedComponent } from './components/recommended/recommended.component';
import { GroupsComponent } from './pages/logged-in/groups/groups.component';
import { GroupComponent } from './pages/logged-in/group/group.component';
import { SearchgroupsComponent } from './components/searchgroups/searchgroups.component';
import { CreateGroupComponent } from './components/create-group/create-group.component';
import { UpdateProfileComponent } from './components/update-profile/update-profile.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { ChangeEmailComponent } from './components/change-email/change-email.component';
import { DeleteUserComponent } from './components/delete-user/delete-user.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    NavComponent,
    FooterComponent,
    LoggedInComponent,
    NotFoundComponent,
    LoadingComponent,
    ProfileComponent,
    HomeComponent,
    LoggedOutComponent,
    ForgotComponent,
    ResetComponent,
    PostsComponent,
    PostComponent,
    SearchComponent,
    CreatePostComponent,
    ProfilepreviewComponent,
    SettingsComponent,
    DetailsComponent,
    ThreadComponent,
    OverviewComponent,
    FriendsComponent,
    RequestsComponent,
    CommentsComponent,
    CommentComponent,
    MainPostComponent,
    CreateCommentComponent,
    RecommendedComponent,
    GroupsComponent,
    GroupComponent,
    SearchgroupsComponent,
    CreateGroupComponent,
    UpdateProfileComponent,
    ChangePasswordComponent,
    ChangeEmailComponent,
    DeleteUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatIconModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorService, multi: true },
    AlertifyService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
