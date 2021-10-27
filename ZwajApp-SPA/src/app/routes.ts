import{Routes} from '@angular/router'
import { HomeComponent } from './home/home.component'
import { ListsComponent } from './lists/lists.component'
import { MemberListComponent } from './member-list/member-list.component'
import { MessagesComponent } from './messages/messages.component'
import { AuthGuard } from './_guards/auth.guard'
import { AuthService } from './_services/auth.service'

export const appRoutes:Routes=[
{path:'',component:HomeComponent},
{path:'members',component:MemberListComponent,runGuardsAndResolvers:'always',canActivate:[AuthGuard]},
{path:'lists',component:ListsComponent,runGuardsAndResolvers:'always',canActivate:[AuthGuard]},
{path:'messages',component:MessagesComponent,runGuardsAndResolvers:'always',canActivate:[AuthGuard]},
{path:'**',redirectTo:'',pathMatch:'full'},
];

// export const appRoutes:Routes=[
//     {path:'',component:HomeComponent},
//     {path:'',runGuardsAndResolvers:'always',canActivate:[AuthService],
//             children:[
//                 {path:'members',component:MemberListComponent},
//                 {path:'lists',component:ListsComponent},
//                 {path:'messages',component:MessagesComponent},
//             ]},
//     {path:'home',component:HomeComponent},
    
//     {path:'**',redirectTo:'home',pathMatch:'full'},
//     ];