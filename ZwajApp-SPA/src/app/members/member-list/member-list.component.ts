import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users?: User[];
  constructor(private userService:UserService,private route:ActivatedRoute,
    private alertify:AlertifyService) { }

  ngOnInit() {
    //this.loadUser();
    this.route.data.subscribe(
      data=>{this.users=data['users']}
    )
  }

  // loadUser(){
  //   this.userService.getUsers().subscribe((users:User[])=>{
  //     this.users=users;
  //     (error: string)=>this.alertify.error(error);
      
  //   });
  // }

}
