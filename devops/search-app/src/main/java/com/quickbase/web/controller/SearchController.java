package com.quickbase.web.controller;

import com.quickbase.web.model.SearchResponseBody;
import com.quickbase.web.model.SearchCriteria;
import com.quickbase.web.model.User;
import org.springframework.util.StringUtils;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.List;

@RestController
public class SearchController {

    List<User> users;

    @RequestMapping(value = "/search/api/getSearchResult")
    public SearchResponseBody getSearchResultViaAjax(@RequestBody SearchCriteria search) {

        SearchResponseBody result = new SearchResponseBody();

        if (isValidSearchCriteria(search)) {
            List<User> users = findByUserNameOrEmail(search.getUsername(), search.getEmail());

            if (users.size() > 0) {
                result.setCode("200");
                result.setMsg("");
                result.setResult(users);
            } else {
                result.setCode("204");
                result.setMsg("No user!");
            }

        } else {
            result.setCode("400");
            result.setMsg("Search criteria is empty!");
        }

        return result;
    }

    private boolean isValidSearchCriteria(SearchCriteria search) {

        boolean valid = true;

        if (search == null) {
            valid = false;
        }

        if ((StringUtils.isEmpty(search.getUsername())) && (StringUtils.isEmpty(search.getEmail()))) {
            valid = false;
        }

        return valid;
    }

    // Initialize with placeholder data
    @PostConstruct
    private void iniDataForTesting() {
        users = new ArrayList<User>();

        User user1 = new User("sam", "pass123", "sam@test.com", "555-555-5555", "5301 6th Street West");
        User user2 = new User("steve", "pass456", "steve@test.com", "555-555-5555", "1496 3rd Street");
        User user3 = new User("susan", "pass789", "susan@test.com", "555-555-5555", "4756 Linden Avenue ");
        users.add(user1);
        users.add(user2);
        users.add(user3);
    }

    private List<User> findByUserNameOrEmail(String username, String email) {
        List<User> result = new ArrayList<User>();
        for (User user : users) {
            if ((!StringUtils.isEmpty(username)) && (!StringUtils.isEmpty(email))) {
                if (username.equals(user.getUsername()) && email.equals(user.getEmail())) {
                    result.add(user);
                    continue;
                } else {
                    continue;
                }

            }
            if (!StringUtils.isEmpty(username)) {
                if (username.equals(user.getUsername())) {
                    result.add(user);
                    continue;
                }
            }

            if (!StringUtils.isEmpty(email)) {
                if (email.equals(user.getEmail())) {
                    result.add(user);
                    continue;
                }
            }
        }
        return result;
    }
}
